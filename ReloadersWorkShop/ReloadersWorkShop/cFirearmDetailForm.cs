//============================================================================*
// cFirearmDetailForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmDetailForm Class
	//============================================================================*

	public partial class cFirearmDetailForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strPurchaseDateToolTip = "The date you purchsed or acquired this firearm.";
		private const string cm_strPriceToolTip = "The amount you paid for this firearm.";

		private const string cm_strFirearmOKButtonToolTip = "Click to add or update the firearm with the above data.";
		private const string cm_strFirearmCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fInitialized = false;
		private bool m_fChanged = false;

		private cFirearm m_Firearm = null;

		private cDataFiles m_DataFiles;
		private bool m_fViewOnly = false;

		private ToolTip m_PurchaseDateToolTip = new ToolTip();
		private ToolTip m_PriceToolTip = new ToolTip();

		private ToolTip m_FirearmOKButtonToolTip = new ToolTip();
		private ToolTip m_FirearmCancelButtonToolTip = new ToolTip();

		private string m_strImagePath = "";

		private string m_strCurrentImagePath = "";

		private List<string> m_ImageList = new List<string>();

		//============================================================================*
		// cFirearmDetailForm() - Constructor
		//============================================================================*

		public cFirearmDetailForm(ref cFirearm Firearm, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_Firearm = new cFirearm(Firearm);
			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			//----------------------------------------------------------------------------*
			// Size the dialog
			//----------------------------------------------------------------------------*

			SetClientSizeCore(AcquisitionDetailsGroupBox.Location.X + AcquisitionDetailsGroupBox.Width + 10, DetailCancelButton.Location.Y + DetailCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				AddImageButton.Click += OnAddImageClicked;
				RemoveImageButton.Click += OnRemoveImageClicked;
				MakePrimaryButton.Click += OnMakePrimaryClicked;

				SourceComboBox.TextChanged += OnSourceChanged;
				PurchaseDateTimePicker.TextChanged += OnPurchaseDateChanged;
				PriceTextBox.TextChanged += OnPriceChanged;

				ReceiverFinishComboBox.TextChanged += OnReceiverFinishChanged;
				ReceiverFinishComboBox.GotFocus += OnFinishComboGotFocus;

				BarrelFinishComboBox.TextChanged += OnBarrelFinishChanged;
				BarrelFinishComboBox.GotFocus += OnFinishComboGotFocus;

				TypeComboBox.SelectedIndexChanged += OnTypeChanged;
				ActionComboBox.SelectedIndexChanged += OnActionChanged;
				HammerComboBox.SelectedIndexChanged += OnHammerChanged;

				MagazineComboBox.SelectedIndexChanged += OnMagazineChanged;
				CapacityTextBox.TextChanged += OnMagazineCapacityChanged;

				NotesTextBox.TextChanged += OnNotesChanged;
				}
			else
				{
				AddImageButton.Enabled = false;
				RemoveImageButton.Enabled = false;
				MakePrimaryButton.Enabled = false;
				}

			PreviousImageButton.Click += OnPreviousImageClicked;
			NextImageButton.Click += OnNextImageClicked;

			//----------------------------------------------------------------------------*
			// Set Measurement Labels
			//----------------------------------------------------------------------------*

			PriceLabel.Text = String.Format("Price ({0}):", m_DataFiles.Preferences.Currency);

			//----------------------------------------------------------------------------*
			// Verify Firearm Image Info
			//----------------------------------------------------------------------------*

			m_strImagePath = Path.Combine(m_DataFiles.GetDataPath(), "Firearm Images");

			if (!Directory.Exists(m_strImagePath))
				Directory.CreateDirectory(m_strImagePath);

			string strFileName = m_Firearm.ImageFileName;

			string[] astrImageFiles = Directory.GetFiles(m_strImagePath, strFileName + "*.*");

			foreach (string strImage in astrImageFiles)
				m_ImageList.Add(strImage);

			if (m_ImageList.Count == 0)
				{
				if (!String.IsNullOrEmpty(m_Firearm.ImageFile))
					{
					try
						{
						string strNewFileName = Path.Combine(m_strImagePath, strFileName);

						strNewFileName = Path.ChangeExtension(strNewFileName, Path.GetExtension(m_Firearm.ImageFile));

						File.Copy(m_Firearm.ImageFile, Path.Combine(m_strImagePath, strNewFileName));

						m_ImageList.Add(strNewFileName);

						m_Firearm.ImageFile = strNewFileName;
						}
					catch
						{
						m_Firearm.ImageFile = "";
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Fill in the firearm data
			//----------------------------------------------------------------------------*

			PopulateFirearmData();

			SetFinishLabels();

			SetStaticToolTips();

			//----------------------------------------------------------------------------*
			// Set title
			//----------------------------------------------------------------------------*

			string strTitle;

			if (!m_fViewOnly)
				strTitle = "Edit Firearm Details";
			else
				strTitle = "View Firearm Details";

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Finish up and exit
			//----------------------------------------------------------------------------*

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}
			}

		//============================================================================*
		// OnActionChanged()
		//============================================================================*

		protected void OnActionChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Action = ActionComboBox.Text;

			if (m_Firearm.Action == "Bolt Action")
				{
				m_Firearm.Hammer = "Striker";

				PopulateHammerCombo();
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnAddImageClicked()
		//============================================================================*

		private void OnAddImageClicked(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Show the file dialog
			//----------------------------------------------------------------------------*

			OpenFileDialog FileDlg = new OpenFileDialog();

			FileDlg.Title = "Select Firearm Image File";
			FileDlg.AddExtension = true;
			FileDlg.CheckFileExists = true;

			if (!String.IsNullOrEmpty(m_DataFiles.Preferences.FirearmImagePath))
				FileDlg.InitialDirectory = m_DataFiles.Preferences.FirearmImagePath;
			else
				FileDlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

			FileDlg.Filter = "Image Files (*.jpg, *.jpeg, *.bmp, *.gif, *.png, *.tiff)|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tiff";

			FileDlg.FileName = "";

			DialogResult rc = FileDlg.ShowDialog();

			if (rc == DialogResult.Cancel)
				return;

			m_DataFiles.Preferences.FirearmImagePath = Path.GetDirectoryName(FileDlg.FileName);

			try
				{
				string strImagePath = Path.Combine(m_DataFiles.GetDataPath(), "Firearm Images");

				string strImageFilePath = Path.Combine(strImagePath, m_Firearm.ImageFileName);

				string strCheckFile = strImageFilePath;

				int nImageNum = 1;

				while (File.Exists(Path.ChangeExtension(strCheckFile, Path.GetExtension(FileDlg.FileName))))
					{
					strCheckFile = strImageFilePath + String.Format(" ({0:D0})", nImageNum);

					nImageNum++;
					}

				strImageFilePath = strCheckFile;

				strImageFilePath = Path.ChangeExtension(strImageFilePath, Path.GetExtension(FileDlg.FileName));

				m_ImageList.Add(strImageFilePath);

				m_strCurrentImagePath = strImageFilePath;

				File.Copy(FileDlg.FileName, strImageFilePath);

				Bitmap FirearmImage = new Bitmap(strImageFilePath);

				FirearmPictureBox.Image = FirearmImage;

				if (String.IsNullOrEmpty(m_Firearm.ImageFile) || Path.GetDirectoryName(strImageFilePath) != Path.GetDirectoryName(m_Firearm.ImageFile))
					m_Firearm.ImageFile = strImageFilePath;

				SetImageDimensions();

				m_fChanged = true;
				}
			catch
				{
				MessageBox.Show("Unable to add the selected image file to this firearm.  Try another", "Image File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnBarrelFinishChanged()
		//============================================================================*

		protected void OnBarrelFinishChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.BarrelFinish = BarrelFinishComboBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnFinishComboGotFocus()
		//============================================================================*

		protected void OnFinishComboGotFocus(object sender, EventArgs e)
			{
			PopulateFinishCombos();

			(sender as ComboBox).Select(0, (sender as ComboBox).Text.Length);
			}

		//============================================================================*
		// OnHammerChanged()
		//============================================================================*

		protected void OnHammerChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Hammer = HammerComboBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagazineChanged()
		//============================================================================*

		protected void OnMagazineChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Magazine = MagazineComboBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagazineCapacityChanged()
		//============================================================================*

		protected void OnMagazineCapacityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.MagazineCapacity = CapacityTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMakePrimaryClicked()
		//============================================================================*

		private void OnMakePrimaryClicked(object sender, EventArgs e)
			{
			m_Firearm.ImageFile = m_strCurrentImagePath;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNextImageClicked()
		//============================================================================*

		private void OnNextImageClicked(object sender, EventArgs e)
			{
			int nImageNum = -1;

			for (int i = 0; i < m_ImageList.Count; i++)
				{
				if (m_ImageList[i] == m_strCurrentImagePath)
					{
					nImageNum = i;

					break;
					}
				}

			if (nImageNum >= 0 && nImageNum < m_ImageList.Count - 1)
				{
				nImageNum++;

				try
					{
					Bitmap ImageBitmap = new Bitmap(m_ImageList[nImageNum]);

					FirearmPictureBox.Image = ImageBitmap;

					m_strCurrentImagePath = m_ImageList[nImageNum];

					SetImageDimensions();
					}
				catch
					{
					// No need to do anything here
					}
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnNotesChanged()
		//============================================================================*

		protected void OnNotesChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Notes = NotesTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPreviousImageClicked()
		//============================================================================*

		private void OnPreviousImageClicked(object sender, EventArgs e)
			{
			int nImageNum = -1;

			for (int i = 0; i < m_ImageList.Count; i++)
				{
				if (m_ImageList[i] == m_strCurrentImagePath)
					{
					nImageNum = i;

					break;
					}
				}

			if (nImageNum > 0)
				{
				nImageNum--;

				try
					{
					Bitmap ImageBitmap = new Bitmap(m_ImageList[nImageNum]);

					FirearmPictureBox.Image = ImageBitmap;

					m_strCurrentImagePath = m_ImageList[nImageNum];

					SetImageDimensions();
					}
				catch
					{
					// No need to do anything here
					}
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnPriceChanged()
		//============================================================================*

		protected void OnPriceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.PurchasePrice = PriceTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPurchaseDateChanged()
		//============================================================================*

		protected void OnPurchaseDateChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.PurchaseDate = PurchaseDateTimePicker.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnReceiverFinishChanged()
		//============================================================================*

		protected void OnReceiverFinishChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.ReceiverFinish = ReceiverFinishComboBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveImageClicked()
		//============================================================================*

		private void OnRemoveImageClicked(object sender, EventArgs e)
			{
			DialogResult rc = MessageBox.Show("Warning: Image file will be deleted from the Reloader's WorkShop data folder\n\nAre you sure you wish to remove this photo?", "Image Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

			if (rc == DialogResult.No)
				return;

			try
				{
				string strFilePath = m_strCurrentImagePath;

				Image FirearmImage = FirearmPictureBox.Image;

				FirearmPictureBox.Image = null;

				FirearmImage.Dispose();

				File.Delete(strFilePath);

				m_ImageList.Remove(m_strCurrentImagePath);

				bool fPrimary = m_Firearm.ImageFile == m_strCurrentImagePath;

				if (m_ImageList.Count > 0)
					{
					m_strCurrentImagePath = m_ImageList[0];

					if (fPrimary)
						m_Firearm.ImageFile = m_strCurrentImagePath;
					}
				else
					{
					m_strCurrentImagePath = "";

					m_Firearm.ImageFile = m_strCurrentImagePath;
					}

				m_fChanged = true;

				PopulateFirearmData();
				}
			catch
				{
				// No need to do anything here
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnSourceChanged()
		//============================================================================*

		protected void OnSourceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Source = SourceComboBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTypeChanged()
		//============================================================================*

		protected void OnTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Type = TypeComboBox.Text;

			SetFinishLabels();

			PopulateActionCombo();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateActionCombo()
		//============================================================================*

		private void PopulateActionCombo()
			{
			ActionComboBox.Items.Clear();

			switch (TypeComboBox.SelectedItem.ToString())
				{
				case "Pistol":
					ActionComboBox.Items.Add("Single Action Automatic");
					ActionComboBox.Items.Add("Double Action Automatic");
					ActionComboBox.Items.Add("Double Action Only");
					ActionComboBox.Items.Add("DA/SA");

					break;

				case "Rifle":
					ActionComboBox.Items.Add("Single Shot");
					ActionComboBox.Items.Add("Bolt Action");
					ActionComboBox.Items.Add("Lever Action");
					ActionComboBox.Items.Add("Semi-Automatic");
					ActionComboBox.Items.Add("Automatic");
					break;

				case "Shotgun":
					ActionComboBox.Items.Add("Pump");
					ActionComboBox.Items.Add("Semi-Automatic");
					ActionComboBox.Items.Add("Bolt Action");
					ActionComboBox.Items.Add("Break Action Single Barreled");
					ActionComboBox.Items.Add("Break Action Double Barreled");
					break;

				default:
					ActionComboBox.Items.Add("Single Action");
					ActionComboBox.Items.Add("Double Action");
					ActionComboBox.Items.Add("Double Action Only");

					break;
				}

			if (string.IsNullOrEmpty(m_Firearm.Action))
				m_Firearm.Action = ActionComboBox.Items[0].ToString();

			ActionComboBox.SelectedItem = m_Firearm.Action;

			if (ActionComboBox.SelectedIndex < 0)
				ActionComboBox.SelectedIndex = 0;

			PopulateHammerCombo();
			}

		//============================================================================*
		// PopulateFinishCombos()
		//============================================================================*

		private void PopulateFinishCombos()
			{
			ReceiverFinishComboBox.BeginUpdate();
			BarrelFinishComboBox.BeginUpdate();

			ReceiverFinishComboBox.Items.Clear();
			BarrelFinishComboBox.Items.Clear();

			//----------------------------------------------------------------------------*
			// Receiver Finishes
			//----------------------------------------------------------------------------*

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				bool fReceiverFinishFound = false;
				bool fBarrelFinishFound = false;

				if (Firearm.ReceiverFinish != null && Firearm.ReceiverFinish.Length > 0)
					{
					//----------------------------------------------------------------------------*
					// ReceiverFinishComboBox
					//----------------------------------------------------------------------------*

					for (int i = 0; i < ReceiverFinishComboBox.Items.Count; i++)
						{
						if (ReceiverFinishComboBox.Items[i].ToString() == Firearm.ReceiverFinish)
							{
							fReceiverFinishFound = true;

							break;
							}
						}

					if (!fReceiverFinishFound)
						ReceiverFinishComboBox.Items.Add(Firearm.ReceiverFinish);

					//----------------------------------------------------------------------------*
					// BarrelFinishComboBox
					//----------------------------------------------------------------------------*

					for (int i = 0; i < BarrelFinishComboBox.Items.Count; i++)
						{
						if (BarrelFinishComboBox.Items[i].ToString() == Firearm.ReceiverFinish)
							{
							fBarrelFinishFound = true;

							break;
							}
						}

					if (!fBarrelFinishFound)
						BarrelFinishComboBox.Items.Add(Firearm.ReceiverFinish);
					}

				//----------------------------------------------------------------------------*
				// Set Selection
				//----------------------------------------------------------------------------*

				if (m_Firearm.ReceiverFinish != null && m_Firearm.ReceiverFinish.Length > 0)
					{
					ReceiverFinishComboBox.SelectedItem = m_Firearm.ReceiverFinish;

					if (ReceiverFinishComboBox.SelectedIndex < 0)
						{
						ReceiverFinishComboBox.Items.Add(m_Firearm.ReceiverFinish);

						ReceiverFinishComboBox.SelectedItem = m_Firearm.ReceiverFinish;
						}
					}

				//----------------------------------------------------------------------------*
				// Barrel Finishes
				//----------------------------------------------------------------------------*

				fReceiverFinishFound = false;
				fBarrelFinishFound = false;

				if (Firearm.BarrelFinish != null && Firearm.BarrelFinish.Length > 0)
					{
					//----------------------------------------------------------------------------*
					// ReceiverFinishComboBox
					//----------------------------------------------------------------------------*

					for (int i = 0; i < ReceiverFinishComboBox.Items.Count; i++)
						{
						if (ReceiverFinishComboBox.Items[i].ToString() == Firearm.BarrelFinish)
							{
							fReceiverFinishFound = true;

							break;
							}
						}

					if (!fReceiverFinishFound)
						ReceiverFinishComboBox.Items.Add(Firearm.BarrelFinish);

					//----------------------------------------------------------------------------*
					// BarrelFinishComboBox
					//----------------------------------------------------------------------------*

					for (int i = 0; i < BarrelFinishComboBox.Items.Count; i++)
						{
						if (BarrelFinishComboBox.Items[i].ToString() == Firearm.BarrelFinish)
							{
							fBarrelFinishFound = true;

							break;
							}
						}

					if (!fBarrelFinishFound)
						BarrelFinishComboBox.Items.Add(Firearm.BarrelFinish);
					}

				//----------------------------------------------------------------------------*
				// Set Selection
				//----------------------------------------------------------------------------*

				if (m_Firearm.BarrelFinish != null && m_Firearm.BarrelFinish.Length > 0)
					{
					BarrelFinishComboBox.SelectedItem = m_Firearm.BarrelFinish;

					if (BarrelFinishComboBox.SelectedIndex < 0)
						{
						BarrelFinishComboBox.Items.Add(m_Firearm.BarrelFinish);

						BarrelFinishComboBox.SelectedItem = m_Firearm.BarrelFinish;
						}
					}
				}

			ReceiverFinishComboBox.EndUpdate();
			BarrelFinishComboBox.EndUpdate();
			}

		//============================================================================*
		// PopulateFirearmData()
		//============================================================================*

		private void PopulateFirearmData()
			{
			FirearmNameLabel.Text = @m_Firearm.ToString();

			//----------------------------------------------------------------------------*
			// Image Data
			//----------------------------------------------------------------------------*

			Bitmap FirearmImage = null;

			try
				{
				if (m_ImageList.Count > 0 || !String.IsNullOrEmpty(m_Firearm.ImageFile))
					{
					if (!String.IsNullOrEmpty(m_Firearm.ImageFile))
						{
						FirearmImage = new Bitmap(m_Firearm.ImageFile);

						m_strCurrentImagePath = m_Firearm.ImageFile;
						}
					else
						{
						FirearmImage = new Bitmap(m_ImageList[0]);

						m_strCurrentImagePath = m_ImageList[0];
						}
					}
				else
					{
					FirearmImage = Properties.Resources.No_Photo_Available;

					m_strCurrentImagePath = "";
					}
				}
			catch
				{
				MessageBox.Show("One or more images file for this firearm have been moved or deleted.  You will need to select a new image.", "Image File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				m_Firearm.ImageFile = null;

				FirearmImage = Properties.Resources.No_Photo_Available;

				m_strCurrentImagePath = "";

				m_fChanged = true;
				}

			FirearmPictureBox.Image = FirearmImage;

			SetImageDimensions();

			//----------------------------------------------------------------------------*
			// Purchase Data
			//----------------------------------------------------------------------------*

			if (m_Firearm.PurchaseDate >= PurchaseDateTimePicker.MinDate && m_Firearm.PurchaseDate <= PurchaseDateTimePicker.MaxDate)
				PurchaseDateTimePicker.Value = m_Firearm.PurchaseDate;
			else
				PurchaseDateTimePicker.Value = DateTime.Today;

			PriceTextBox.Value = m_Firearm.PurchasePrice;

			//----------------------------------------------------------------------------*
			// Notes
			//----------------------------------------------------------------------------*

			NotesTextBox.Text = m_Firearm.Notes;

			//----------------------------------------------------------------------------*
			// Start the chain of combo box population code
			//----------------------------------------------------------------------------*

			PopulateSourceCombo();

			PopulateFinishCombos();
			}

		//============================================================================*
		// PopulateHammerCombo()
		//============================================================================*

		private void PopulateHammerCombo()
			{
			HammerComboBox.Items.Clear();

			HammerComboBox.Items.Add("External");
			HammerComboBox.Items.Add("Internal");

			if (m_Firearm.Type == "Pistol")
				HammerComboBox.Items.Add("Striker Fired");

			if (string.IsNullOrEmpty(m_Firearm.Hammer))
				m_Firearm.Hammer = HammerComboBox.Items[0].ToString();

			HammerComboBox.SelectedItem = m_Firearm.Hammer;

			if (HammerComboBox.SelectedIndex < 0 && HammerComboBox.Items.Count > 0)
				HammerComboBox.SelectedIndex = 0;
			}

		//============================================================================*
		// PopulateMagazineData()
		//============================================================================*

		private void PopulateMagazineData()
			{
			MagazineComboBox.Items.Clear();

			MagazineComboBox.Items.Add("None");
			MagazineComboBox.Items.Add("Cylinder");
			MagazineComboBox.Items.Add("Internal");
			MagazineComboBox.Items.Add("Removable");
			MagazineComboBox.Items.Add("Tubular");

			if (string.IsNullOrEmpty(m_Firearm.Magazine))
				m_Firearm.Magazine = MagazineComboBox.Items[0].ToString();

			MagazineComboBox.SelectedItem = m_Firearm.Magazine;

			if (MagazineComboBox.SelectedIndex < 0 && MagazineComboBox.Items.Count > 0)
				MagazineComboBox.SelectedIndex = 0;

			CapacityTextBox.MinValue = 1;
			CapacityTextBox.Value = m_Firearm.MagazineCapacity;
			}

		//============================================================================*
		// PopulateSourceCombo()
		//============================================================================*

		private void PopulateSourceCombo()
			{
			SourceComboBox.Items.Clear();

			if (m_Firearm.Source != null && m_Firearm.Source.Length > 0)
				SourceComboBox.Items.Add(m_Firearm.Source);

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				bool fSourceFound = false;

				for (int i = 0; i < SourceComboBox.Items.Count; i++)
					{
					if (SourceComboBox.Items[i].ToString() == Firearm.Source)
						{
						fSourceFound = true;

						break;
						}
					}

				if (!fSourceFound && Firearm.Source != null && Firearm.Source.Length > 0)
					SourceComboBox.Items.Add(Firearm.Source);
				}

			SourceComboBox.SelectedItem = m_Firearm.Source;

			PopulateTypeCombo();
			}

		//============================================================================*
		// PopulateTypeCombo()
		//============================================================================*

		private void PopulateTypeCombo()
			{
			TypeComboBox.Items.Clear();

			switch (m_Firearm.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					TypeComboBox.Items.Add("Revolver");
					TypeComboBox.Items.Add("Pistol");
					TypeComboBox.Items.Add("Derringer");

					break;

				case cFirearm.eFireArmType.Rifle:
					TypeComboBox.Items.Add("Rifle");
					break;

				case cFirearm.eFireArmType.Shotgun:
					TypeComboBox.Items.Add("Shotgun");
					break;
				}

			TypeComboBox.SelectedItem = m_Firearm.Type;

			if (TypeComboBox.SelectedIndex < 0)
				TypeComboBox.SelectedIndex = 0;

			if (string.IsNullOrEmpty(m_Firearm.Type))
				m_Firearm.Type = TypeComboBox.SelectedItem.ToString();

			PopulateActionCombo();
			}

		//============================================================================*
		// SetFinishLabels()
		//============================================================================*

		private void SetFinishLabels()
			{
			string strReceiver = "";
			string strBarrel = "";

			switch (TypeComboBox.Text)
				{
				case "Rifle":
				case "Shotgun":
					strReceiver = "Receiver Finish:";
					strBarrel = "Barrel Finish";
					break;

				case "Pistol":
					strReceiver = "Frame Finish:";
					strBarrel = "Slide Finish:";
					break;

				case "Revolver":
					strReceiver = "Frame Finish:";
					strBarrel = "Cylinder Finish:";
					break;

				default:
					strReceiver = "Frame Finish:";
					strBarrel = "Barrel Finish:";
					break;
				}

			Graphics gr = Graphics.FromHwnd(this.Handle);

			Point LabelLocation = ReceiverFinishLabel.Location;
			SizeF LabelSize = ReceiverFinishLabel.Size;

			SizeF TextSize = gr.MeasureString(strReceiver, ReceiverFinishLabel.Font);

			ReceiverFinishLabel.Text = strReceiver;

			ReceiverFinishLabel.Location = new Point((int) (LabelLocation.X + LabelSize.Width - TextSize.Width), (int) LabelLocation.Y);

			LabelLocation = BarrelFinishLabel.Location;
			LabelSize = BarrelFinishLabel.Size;

			TextSize = gr.MeasureString(strBarrel, BarrelFinishLabel.Font);

			BarrelFinishLabel.Text = strBarrel;

			BarrelFinishLabel.Location = new Point((int) (LabelLocation.X + LabelSize.Width - TextSize.Width), (int) LabelLocation.Y);
			}

		//============================================================================*
		// SetImageDimensions()
		//============================================================================*

		private void SetImageDimensions()
			{
			if (FirearmPictureBox.Image == null)
				return;

			FirearmPictureBox.Size = new Size(480, 270);
			FirearmPictureBox.Location = new Point(126, 23);

			double dWidth = FirearmPictureBox.Image.Width;
			double dHeight = FirearmPictureBox.Image.Height;

			if (dWidth > 480.0 || dHeight > 270.0)
				{
				if (dWidth > 480.0)
					{
					dHeight = dHeight / dWidth;
					dWidth = 480.0;
					dHeight *= dWidth;

					if (dHeight > 270.0)
						{
						dWidth = dWidth / dHeight;
						dHeight = 270.0;
						dWidth *= dHeight;
						}
					}
				else
					{
					dWidth = dWidth / dHeight;
					dHeight = 270.0;
					dWidth *= dHeight;

					if (dWidth > 480.0)
						{
						dHeight = dHeight / dWidth;
						dWidth = 480.0;
						dHeight *= dWidth;
						}
					}
				}

			FirearmPictureBox.Size = new Size((int) dWidth, (int) dHeight);

			FirearmPictureBox.Location = new Point((FirearmImageGroupBox.Width / 2) - (FirearmPictureBox.Width / 2), FirearmPictureBox.Location.Y + 135 - (FirearmPictureBox.Height / 2));
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Check Image Buttons
			//----------------------------------------------------------------------------*

			if (!String.IsNullOrEmpty(m_strCurrentImagePath))
				{
				if (m_strCurrentImagePath != m_Firearm.ImageFile)
					MakePrimaryButton.Enabled = !m_fViewOnly;
				else
					MakePrimaryButton.Enabled = false;

				if (m_ImageList.Count < 2)
					{
					PreviousImageButton.Enabled = false;
					NextImageButton.Enabled = false;
					}
				else
					{
					for (int i = 0; i < m_ImageList.Count; i++)
						{
						if (m_ImageList[i] == m_strCurrentImagePath)
							{
							if (i > 0)
								PreviousImageButton.Enabled = true;
							else
								PreviousImageButton.Enabled = false;

							if (i < m_ImageList.Count - 1)
								NextImageButton.Enabled = true;
							else
								NextImageButton.Enabled = false;
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// If we're View Only, exit
			//----------------------------------------------------------------------------*

			if (m_fViewOnly)
				return;

			//----------------------------------------------------------------------------*
			// Check Type
			//----------------------------------------------------------------------------*

			if (TypeComboBox.Text == "Revolver")
				{
				MagazineComboBox.SelectedItem = "Cylinder";
				MagazineComboBox.Enabled = false;
				}
			else
				MagazineComboBox.Enabled = true;

			//----------------------------------------------------------------------------*
			// Check Capacity
			//----------------------------------------------------------------------------*

			if (!CapacityTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
