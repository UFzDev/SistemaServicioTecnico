using System.Data;
namespace SistemaServicioTecnico.BLL
{
    public class DashboardBLL
    {
        private readonly DAL.DashboardDAL _dashboardDAL = new DAL.DashboardDAL();
        public DataSet ObtenerReporte() { return _dashboardDAL.ObtenerReporte(); }
    }
}
