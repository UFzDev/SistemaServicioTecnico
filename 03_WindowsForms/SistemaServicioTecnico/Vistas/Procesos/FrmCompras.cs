using System;
using System.Data;
using System.Windows.Forms;
using SistemaServicioTecnico.BLL;

namespace SistemaServicioTecnico.Vistas.Procesos
{
    public partial class FrmCompras : Form
    {
        private readonly CompraBLL _compraBLL = new CompraBLL();
        private readonly RefaccionBLL _refaccionBLL = new RefaccionBLL();
        private readonly int _idUsuarioActual;
        private DataTable _dtProveedores;
        private DataTable _dtCompras;

        public FrmCompras() : this(1)
        {
        }

        public FrmCompras(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                CargarProveedores();
                CargarRefaccionesCombo();
                CargarCompras();
                PrepararFolioCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar compras y proveedores: " + ex.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            _dtProveedores = _compraBLL.ObtenerProveedores();
            dgvProveedores.DataSource = _dtProveedores;
            if (dgvProveedores.Columns["IdProveedor"] != null)
                dgvProveedores.Columns["IdProveedor"].Visible = false;

            cboProveedorCompra.DataSource = _dtProveedores.Copy();
            cboProveedorCompra.DisplayMember = "Empresa";
            cboProveedorCompra.ValueMember = "IdProveedor";
        }

        private void CargarRefaccionesCombo()
        {
            DataTable dtRef = _refaccionBLL.ObtenerRefacciones();
            DataView dvActivas = new DataView(dtRef);
            dvActivas.RowFilter = "Activo = true";

            cboRefaccionCompra.DataSource = dvActivas;
            cboRefaccionCompra.DisplayMember = "Nombre";
            cboRefaccionCompra.ValueMember = "IdRefaccion";
        }

        private void CargarCompras()
        {
            _dtCompras = _compraBLL.ObtenerCompras();
            dgvCompras.DataSource = _dtCompras;
            if (dgvCompras.Columns["Total"] != null)
                dgvCompras.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        private void PrepararFolioCompra()
        {
            txtFolioCompra.Text = _compraBLL.ObtenerSiguienteFolio();
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProv.Text))
            {
                MessageBox.Show("El nombre de la empresa proveedora es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _compraBLL.GuardarProveedor(
                    txtNombreProv.Text,
                    txtRFCProv.Text,
                    txtContactoProv.Text,
                    txtTelProv.Text);

                CargarProveedores();
                txtNombreProv.Clear();
                txtRFCProv.Clear();
                txtContactoProv.Clear();
                txtTelProv.Clear();

                MessageBox.Show("Proveedor registrado exitosamente en SQL Server.", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (cboProveedorCompra.SelectedValue == null || cboRefaccionCompra.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar proveedor y refacción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cant = 0;
            decimal costo = 0;
            int.TryParse(txtCantidadCompra.Text, out cant);
            decimal.TryParse(txtCostoUnitario.Text, out costo);

            if (cant <= 0 || costo <= 0)
            {
                MessageBox.Show("La cantidad y el costo unitario deben ser mayores a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProveedor = Convert.ToInt32(cboProveedorCompra.SelectedValue);
                int idRefaccion = Convert.ToInt32(cboRefaccionCompra.SelectedValue);
                string folioMostrado = txtFolioCompra.Text;

                _compraBLL.RegistrarCompra(idProveedor, _idUsuarioActual, idRefaccion, cant, costo);

                CargarCompras();
                PrepararFolioCompra();

                decimal total = cant * costo;
                MessageBox.Show(string.Format("Orden de compra [{0}] registrada por {1:C2} (stock actualizado).", folioMostrado, total), "Compra Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
