using System.Windows.Forms;

namespace ReloadersWorkShop
	{
	public partial class cDataIntegrityForm : Form
		{
		cDataFiles m_DataFiles = null;
		cDataIntegrity m_DataIntegrity = null;

		public cDataIntegrityForm(cDataFiles DataFiles)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			m_DataIntegrity = new cDataIntegrity(m_DataFiles);

			PopulateSummaryTextBox();

			SetClientSizeCore(SummaryGroupBox.Location.X + SummaryGroupBox.Width + 12, OKButton.Location.Y + OKButton.Height + 20);
			}

		private void AppendSummaryText(string strItem, int nNumItems, int nNumBadItems, int nIndentLevel = 0)
			{
			string strFormat = "";

			for (int i = 0; i < nIndentLevel; i++)
				strFormat += "    ";

			strFormat += "{0:N0} {1}{2} - {3} issue{4}\r\n";

			SummaryTextBox.AppendText(string.Format(strFormat, nNumItems, strItem, nNumItems != 1 ? "s" : "", (nNumBadItems == 0) ? "No" : nNumBadItems.ToString() + " minor", nNumBadItems != 1 ? "s" : ""));
			}

		public void PopulateSummaryTextBox()
			{
			AppendSummaryText("Manufacturer", m_DataIntegrity.NumManufacturers, m_DataIntegrity.NumBadManufacturers);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Caliber", m_DataIntegrity.NumCalibers, m_DataIntegrity.NumBadCalibers);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Firearm", m_DataIntegrity.NumFirearms, m_DataIntegrity.NumBadFirearms);

			AppendSummaryText("Usable Cartridge Record", m_DataIntegrity.NumFirearmCalibers, m_DataIntegrity.NumBadFirearmCalibers, 1);
			AppendSummaryText("Bullet Specific Record", m_DataIntegrity.NumFirearmBullets, m_DataIntegrity.NumBadFirearmBullets, 1);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Ammo Record", m_DataIntegrity.NumAmmo, m_DataIntegrity.NumBadAmmo);
			AppendSummaryText("Ammo Test", m_DataIntegrity.NumAmmoTests, m_DataIntegrity.NumBadAmmoTests, 1);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Bullet", m_DataIntegrity.NumBullets, m_DataIntegrity.NumBadBullets);
			AppendSummaryText("Cartridge Specific Data Record", m_DataIntegrity.NumBulletCalibers, m_DataIntegrity.NumBadBulletCalibers, 1);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Case", m_DataIntegrity.NumCases, m_DataIntegrity.NumBadCases);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Powder", m_DataIntegrity.NumPowders, m_DataIntegrity.NumBadPowders);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Primer", m_DataIntegrity.NumPrimers, m_DataIntegrity.NumBadPrimers);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Load", m_DataIntegrity.NumLoads, m_DataIntegrity.NumBadLoads);
			AppendSummaryText("Charge", m_DataIntegrity.NumCharges, m_DataIntegrity.NumBadCharges, 1);
			AppendSummaryText("Charge Test", m_DataIntegrity.NumChargeTests, m_DataIntegrity.NumBadChargeTests, 1);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Batch" + (m_DataIntegrity.NumBatches != 1 ? "e" : ""), m_DataIntegrity.NumBatches, m_DataIntegrity.NumBadBatches);
			AppendSummaryText("Batch Test", m_DataIntegrity.NumBatchTests, m_DataIntegrity.NumBadBatchTests, 1);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Test Shot", m_DataIntegrity.NumTestShots, m_DataIntegrity.NumBadTestShots);
			SummaryTextBox.AppendText("\r\n");

			AppendSummaryText("Inventory Transaction", m_DataIntegrity.NumTransactions, m_DataIntegrity.NumBadTransactions);
			SummaryTextBox.AppendText("\r\n");
			}
		}
	}
