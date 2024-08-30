using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Attributes;
using Domain.Crud;


namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //variables
        CPersonas personas = new CPersonas();
        AttributePeople attributes = new AttributePeople();
        bool edit = false;


        private void getData()
        {
            CPersonas cPersonas = new CPersonas();
            dgvDatos.DataSource = cPersonas.Mostrar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;
            btnGuardar.Enabled = false;
            getData();
        }

        private void ClearTextBox()
        {
            txtID.Text = "ID";
            txtApellido.Text = "Apellido";
            txtNombre.Text = "Nombre";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                //INSERTAR
                try
                {            
                    attributes.ID = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cbSexo.Text;
                    personas.Insertar(attributes);
                    ClearTextBox();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("SE GUARDÓ UN REGISTRO DE FORMA EXITOSA", "INSERTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else if (edit == true)
            {
                //ACTUALIZAR
                try
                {
                    attributes.ID = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cbSexo.Text;
                    personas.Modificar(attributes);
                    ClearTextBox();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("SE ACTUALIZÓ UN REGISTRO DE FORMA EXITOSA", "MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {            
            if (dgvDatos.SelectedRows.Count > 0)
            {
                txtID.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //CARGAR DATOS
                txtID.Text = dgvDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...") txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar...";
                getData();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("¿DESEAS ELIMINAR ESTE REGISTRO", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        attributes.ID = Convert.ToInt32 (dgvDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(attributes);
                        getData();
                        MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "ELIMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CPersonas cPersonas = new CPersonas();
            dgvDatos.DataSource = cPersonas.Buscar(txtBuscar.Text);
        }
    }
}
