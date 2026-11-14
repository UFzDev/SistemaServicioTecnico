namespace SistemaServicioTecnico.BLL
{
    public class DashboardBLL
    {
        private readonly DAL.DashboardDAL _dashboardDAL = new DAL.DashboardDAL();

        public void ObtenerResumen(out int ordenesActivas, out int enReparacion, out int totalClientes, out int stockAlerta)
        {
            _dashboardDAL.ObtenerResumen(out ordenesActivas, out enReparacion, out totalClientes, out stockAlerta);
        }
    }
}
