using DonaLaura.Application.Features;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Data.Features.Sales;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Sales
{
    public partial class SaleControl : UserControl
    {
        private ISaleRepository _saleRepository;
        private SaleService _saleService;

        public SaleControl()
        {
            InitializeComponent();

            _saleRepository = new SaleRepository();
            _saleService = new SaleService(_saleRepository);
        }

        public void PopulateSalesLinsting(IList<Sale> sales)
        {
            dgvSale.DataSource = null;

            if (sales == null)
                return;

            dgvSale.DataSource = sales;
            SetDataGrid();
        }

        public Sale GetSelectedSale()
        {
            try
            {
                return dgvSale.CurrentRow.DataBoundItem as Sale;
            }
            catch
            {
                return null;
            }
        }

        private void SetDataGrid()
        {
            dgvSale.Columns["ID"].Visible = false;
            dgvSale.Columns["PRODUTOS"].Visible = false;
        }
    }
}
