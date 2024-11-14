using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PuntoVentas
{
    public partial class Form1 : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Rubro> rubros = new List<Rubro>();
        private List<Proveedor> proveedores = new List<Proveedor>();
        private List<Producto> productos = new List<Producto>();
        private List<Pedido> pedidos = new List<Pedido>();
        private List<Pedido_Item> pedidos_items = new List<Pedido_Item>();


        int indiceFila = -1;
        private ConexionDB conexionDB;
        public String moduloActual = "";
        int pedidoEnCurso = 0;
        double totalGralPedido = 0.00;
        int UltimoItemPedido = 0;

        public Form1()
        {
            conexionDB = new ConexionDB("localhost", "root", " ", "crud"); //Ruta XAMMP
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal; // Tamaño de la ventana. Maximizar
        }

        private void ActualizartotalPedido(int p, double t)
        {
            using (MySqlConnection conexion = conexionDB.ObtenerConexion())
            {
                //Actualizar datos en la Base de datos
                string consulta = "UPDATE pedidos SET total = '" + t + "' WHERE Id_Pedidos = " + p;
                if (ejecutarTransaccion(consulta))
                {
                    msje("Datos Actualizados en: " + moduloActual);
                }
            }
        }

        private void CargarItems(string sql) // leer items pedido en DB
        {
            try
            { //Preparar coleccion 
                pedidos_items.Clear();
                if (conexionDB != null)
                {
                    using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                    {
                        conexion.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexion);
                        MySqlDataReader leerDatos = comando.ExecuteReader();
                        while (leerDatos.Read())
                        {
                            pedidos_items.Add(new Pedido_Item { Id = leerDatos.GetInt32("Id_Pedidos_Items"), Id_Pedido = leerDatos.GetInt32("Id_Pedidos"), Id_Producto = leerDatos.GetInt32("Id_Producto"), Cantidad = leerDatos.GetInt32("cantidad"), Precio = leerDatos.GetDouble("precio"), NombreProducto = leerDatos.GetString("producto") });

                        }

                    }

                }
                else
                {
                    MessageBox.Show("La conexión no está configurada correctamente");
                }
                ActualizarDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }





        #region METODOS

        private void CargarDatos(string sql) //  metodo leer DB
        {
            try
            {
                textBox1_idInvisible.Text = ""; // reset oculto
                dataGridView1.Enabled = true; // habilitar grid
                // preparar colecciones 
                if (moduloActual == "usuarios") { usuarios.Clear(); }
                if (moduloActual == "rubros") { rubros.Clear(); }
                if (moduloActual == "proveedores") { proveedores.Clear(); }
                if (moduloActual == "productos") { productos.Clear(); }
                if (moduloActual == "pedidos") { pedidos.Clear(); }

                if (conexionDB != null)
                {
                    //Leer Base de datos

                    using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                    {
                        conexion.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexion);
                        MySqlDataReader leerDatos = comando.ExecuteReader();
                        while (leerDatos.Read()) // lee y recorre cada fila leida de la DB
                        {
                            if (moduloActual == "usuarios")
                            {
                                usuarios.Add(new Usuario { Id = leerDatos.GetInt32("Id_Usuarios"), Nombre = leerDatos.GetString("Nombre"), Direccion = leerDatos.GetString("Direccion"), Email = leerDatos.GetString("Email"), Telefono = leerDatos.GetInt32("Telefono") });
                            }
                            if (moduloActual == "rubros")
                            {
                                rubros.Add(new Rubro { Id = leerDatos.GetInt32("Id_Rubro"), Nombre = leerDatos.GetString("nombre") });
                            }
                            if (moduloActual == "proveedores")
                            {
                                proveedores.Add(new Proveedor { Id = leerDatos.GetInt32("Id_Proveedores"), Nombre = leerDatos.GetString("Nombre") });
                            }
                            if (moduloActual == "productos")
                            {
                                productos.Add(new Producto { Id = leerDatos.GetInt32("Id_Productos"), Nombre = leerDatos.GetString("Nombre"), Costo = leerDatos.GetDouble("Costo"), Precio = leerDatos.GetDouble("Precio"), Id_Rubro = leerDatos.GetInt32("Id_Rubro"), Id_Proveedor = leerDatos.GetInt32("Id_Proveedores"), NombreRubro = leerDatos.GetString("rubro"), NombreProveedor = leerDatos.GetString("proveedor") });
                            }
                            if (moduloActual == "pedidos")
                            {
                                pedidos.Add(new Pedido { Id = leerDatos.GetInt32("Id_Pedidos"), Fecha = leerDatos.GetDateTime("Fecha"), Id_Usuario = leerDatos.GetInt32("Id_Usuario"), Total = leerDatos.GetDouble("total"), NombreUsuario = leerDatos.GetString("usuario")});
                            }

                        }

                    }
                }
                else
                {
                    MessageBox.Show("La conexión no esta configurada correctamente");
                }
                ActualizarDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos:" + ex.Message);
            }
        }

        private void msje(string str) //Metodo mensaje
        {
            mensaje.Text = str;
            mensaje.Visible = true;
            mensaje.Refresh();
            espera(3);
            mensaje.Text = "";
            mensaje.Visible = false;
        }

        public Boolean ejecutarTransaccion(string sql) // Metodo Ejecutar Transaccion 
        {
            using (MySqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();
                MySqlTransaction transaccion = conexion.BeginTransaction();
                try
                {
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Transaction = transaccion; // verifica consistencia e integridad de datos
                    comando.ExecuteNonQuery();
                    transaccion.Commit(); // Si todo sale bien, confirma los cambios
                    if (moduloActual == "pedidos" && pedidoEnCurso == 0)
                    { // Obtener IdPedido para vincular con pedidosItems
                        pedidoEnCurso = Convert.ToInt32(comando.LastInsertedId);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback(); // Si ocurre un error, deshace los cambios
                    MessageBox.Show("Error en la transacción. Los datos no han sido guardados.\nError: " + ex.Message);
                    return false;
                    //hacer  un log de errores. 
                    //Enviar email con el error. Avisar por algún medio al admin (datos del proceso no realizado)
                    //procesar nuevamnete el registro
                }
            }
        }

        private void ActualizarDataGrid()  //Actualizar el DataGridview
        {
            dataGridView1.DataSource = null;
            if (moduloActual == "usuarios")
            {
                dataGridView1.DataSource = usuarios;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 185;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 220;
                dataGridView1.Refresh();
            }
            if (moduloActual == "rubros")
            {
                dataGridView1.DataSource = rubros;
                dataGridView1.Columns[1].Width = 220;
            }
            if (moduloActual == "proveedores")
            {
                dataGridView1.DataSource = proveedores;
                dataGridView1.Columns[1].Width = 185;
            }
            if (moduloActual == "productos")
            {
                dataGridView1.DataSource = productos;
                dataGridView1.Columns[1].Width = 185;
                dataGridView1.Columns[2].Visible = false; //Ocultar Columnas del Id rubros
                dataGridView1.Columns[3].Visible = false; //Ocultar Columnas del Id proveedor
            }
            if (moduloActual == "pedidos")
            {
                dataGridView1.DataSource = pedidos;
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[4].Width = 170;
                dataGridView1.Width = 550;
            }
        }

        private void LimpiarDatos() // Limpiar Datos
        {
            textBox1_idInvisible.Text = "";
            indiceFila = -1;
            //usuarios
            textBox1_UsuarioNombres.Text = "";
            textBox2_UsuariosDireccion.Text = "";
            textBox3_UsuariosEmail.Text = "";
            textBox4_UsuariosTelefono.Text = "";
            //rubros
            textBox1_RubrosNombre.Text = "";
            // proveedores 
            textBox1_Proveedores.Text = "";
            // productos 
            textBox1_ProductoNombre.Text = "";
            comboBox1_Producto_Rubros.Text = "Seleccione";
            comboBox2_Productos_Proveedor.Text = "Seleccione";
            textBox2_CostoProducto.Text = "";
            textBox3_PrecioProductos.Text = "";
            //pedidos 
            comboBox1_Pedidos.Enabled = true;
            button1_AgregarPedido.Enabled = true;
            button1_AgregarPedido.Visible = true;
            button3_PedidosCerrar.Visible = false;
            dataGridView2.DataSource = null;
            pedidos_items.Clear();
        }

        public void espera(int nn)
        {
            Thread.Sleep(nn * 1000);
        }

        private void ocultar_grupos() // Metodo Ocultar grupos
        {
            textBox1_idInvisible.Text = ""; indiceFila = -1;
            groupBox1_usuarios.Visible = false;
            groupBox1_Rubros.Visible = false;
            groupBox1_Proveedores.Visible = false;
            groupBox1_Pedidos.Visible = false;
            groupBox1_ItemPedido.Visible = false;
            groupBox1_Productos.Visible = false;
        }

        public string BuscarPrecioProducto(Decimal p) // Metodo Buscar precio 
        {
            double precio = 0;
            try
            {
                if (conexionDB != null)
                {
                    //leer Datos de BD
                    using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                    {
                        string sql = "SELECT * FROM productos  WHERE Id_Productos= " + p;

                        conexion.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexion);
                        MySqlDataReader leerdatos = comando.ExecuteReader();
                        while (leerdatos.Read()) //Lee y recorre cada fila de la Base de Datos
                        {
                            precio = leerdatos.GetDouble("precio");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("La Conexion no esta configurada correctamente.");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error en la consulta: " + ex.Message);
            }

            return precio.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Seleccion en Grid
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //asignamos numero de fila sellecionada para luego actualizar
                indiceFila = dataGridView1.CurrentRow.Index;

                //Obtener la fila seleccionada y mostrarla en textBox
                DataGridViewRow filaSelecionada = dataGridView1.Rows[e.RowIndex];

                //Obtener los valores de las celdas y asignarlos a los TextBox
                if (moduloActual == "usuarios")
                {
                    textBox1_idInvisible.Text = filaSelecionada.Cells["Id"].Value.ToString();
                    textBox1_UsuarioNombres.Text = filaSelecionada.Cells["Nombre"].Value.ToString();
                    textBox2_UsuariosDireccion.Text = filaSelecionada.Cells["Direccion"].Value.ToString();
                    textBox3_UsuariosEmail.Text = filaSelecionada.Cells["Email"].Value.ToString();
                    textBox4_UsuariosTelefono.Text = filaSelecionada.Cells["Telefono"].Value.ToString();
                }
                if (moduloActual == "rubros")
                {
                    textBox1_idInvisible.Text = filaSelecionada.Cells["Id"].Value.ToString();
                    textBox1_RubrosNombre.Text = filaSelecionada.Cells["Nombre"].Value.ToString();
                }
                if (moduloActual == "proveedores")
                {
                    textBox1_idInvisible.Text = filaSelecionada.Cells["Id"].Value.ToString();
                    textBox1_Proveedores.Text = filaSelecionada.Cells["Nombre"].Value.ToString();
                }
                if (moduloActual == "productos")
                {
                    textBox1_idInvisible.Text = filaSelecionada.Cells["Id"].Value.ToString();
                    textBox1_ProductoNombre.Text = filaSelecionada.Cells["Nombre"].Value.ToString();
                    comboBox1_Producto_Rubros.SelectedValue = filaSelecionada.Cells["Id_Rubro"].Value;
                    comboBox2_Productos_Proveedor.SelectedValue = filaSelecionada.Cells["Id_Proveedor"].Value;
                    textBox2_CostoProducto.Text = filaSelecionada.Cells["Costo"].Value.ToString();
                    textBox3_PrecioProductos.Text = filaSelecionada.Cells["Precio"].Value.ToString();
                }
                if (moduloActual == "pedidos")
                {
                    dataGridView2.DataSource = null;

                    textBox1_idInvisible.Text = filaSelecionada.Cells["Id"].Value.ToString();
                    pedidoEnCurso = Convert.ToInt32(textBox1_idInvisible.Text);
                    textBox1_idInvisible.Text = "";

                    comboBox1_Pedidos.SelectedValue = Convert.ToInt32(filaSelecionada.Cells["Id_Usuario"].Value);
                    textBox1_TotalPedido.Text = Convert.ToDouble(filaSelecionada.Cells["total"].Value).ToString();
                    totalGralPedido = Convert.ToDouble(textBox1_TotalPedido.Text);

                    comboBox1_Pedidos.Enabled = false;
                    button1_AgregarPedido.Enabled = false;
                    button3_PedidosCerrar.Visible = true;
                    CargarItems("select it.*, p.nombre as producto from pedidos_items it inner join productos p on p.Id_Productos = it.Id_Producto where Id_Pedidos =" + pedidoEnCurso);
                    dataGridView2.Visible = true;
                    dataGridView2.Location = new Point(600, 224);
                    dataGridView2.Size = new Size(500, 300);
                    dataGridView2.DataSource = pedidos_items;
                    dataGridView2.Columns[0].Width = 50;
                    dataGridView2.Columns[1].Width = 60;
                    dataGridView2.Columns[2].Width = 70;
                    dataGridView2.Columns[3].Width = 80;
                    dataGridView2.Columns[4].Width = 80;
                    dataGridView2.Columns[5].Width = 116;
                    groupBox1_ItemPedido.Visible = true;
                    groupBox1_ItemPedido.Location = new Point(600, 55);
                    groupBox1_ItemPedido.Size = new Size(500, 163);
                    groupBox1_ItemPedido.Text = "Items Pedido N° [" + pedidoEnCurso + "]";
                    llenar_combo_Productos();
                    dataGridView1.Enabled = false;
                    dataGridView2.Visible = true;
                    dataGridView2.Location = new Point(600, 224);
                    dataGridView2.Size = new Size(500, 300);
                    dataGridView2.Refresh();
                    //button15.Visible = false;
                    //button16.Visible = true;
                }
                //Deshabilitar el DataGridView cuando se seleciona una fila
                // dataGridView1.Enabled = false; // Congela el data grid
            }

        }
        #endregion

        #region LLenar Combox

        public void llenar_combo_Clientes() // Metodo llenar Combox Clientes
        {
            if (conexionDB != null)
            {
                //leer Datos de BD
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                {
                    string sql = "SELECT * FROM usuarios ";
                    usuarios.Clear();
                    usuarios.Add(new Usuario { Id = 0, Nombre = "Seleccione " });
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    MySqlDataReader leerdatos = comando.ExecuteReader();
                    while (leerdatos.Read()) // lee y recorre cada fila de la Base de Datos
                    {
                        usuarios.Add(new Usuario { Id = leerdatos.GetInt32("Id_Usuarios"), Nombre = leerdatos.GetString("Nombre"), Direccion = leerdatos.GetString("Direccion"), Email = leerdatos.GetString("Email"), Telefono = leerdatos.GetInt32("Telefono") });
                    }
                }
            }
            else
            {
                MessageBox.Show("La Conexion no esta configurada correctamente.");
            }
            //Establecer el origen de datos del ComboBox
            comboBox1_Pedidos.DataSource = usuarios;
            //Especificar que propiedad se mostrara en el ComboBox
            comboBox1_Pedidos.DisplayMember = "Nombre";
            //Especificar que propiedad se mostrara en el ComboBox
            comboBox1_Pedidos.ValueMember = "Id";

        }

        public void llenar_combo_Productos() //Combox Productos
        {
            if (conexionDB != null)
            {
                //leer Datos de BD
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                {
                    string sql = "SELECT p.*, r.Nombre AS rubro, pr.Nombre AS proveedor " + "FROM productos p " + "INNER JOIN rubros r ON p.Id_Rubro = r.Id_Rubro " + "INNER JOIN proveedores pr ON p.Id_Proveedores = pr.Id_Proveedores";
                    productos.Clear();
                    productos.Add(new Producto { Id = 0, Nombre = "Seleccione " });
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    MySqlDataReader leerdatos = comando.ExecuteReader();
                    while (leerdatos.Read())
                    {
                        productos.Add(new Producto { Id = leerdatos.GetInt32("Id_Productos"), Nombre = leerdatos.GetString("Nombre"), Id_Proveedor = leerdatos.GetInt32("Id_Proveedores"), Id_Rubro = leerdatos.GetInt32("Id_Rubro"), Costo = leerdatos.GetDouble("costo"), Precio = leerdatos.GetDouble("Precio"), NombreProveedor = leerdatos.GetString("Proveedor"), NombreRubro = leerdatos.GetString("Rubro") });
                    }
                }
            }
            else
            {
                MessageBox.Show("La Conexion no esta configurada correctamente.");
            }
            //Establecer el origen de datos del ComboBox
            comboBox2_PedidoItem.DataSource = productos;
            //Especificar que propiedad se mostrara en el ComboBox
            comboBox2_PedidoItem.DisplayMember = "Nombre";
            //Especificar que propiedad se usara como valor
            comboBox2_PedidoItem.ValueMember = "Id";
        }

        private void llenarcomboBox1_Producto_Rubros() // Llenar combox
        {
            if (conexionDB != null)
            {
                //leer Datos de DB
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                {
                    String sql = "SELECT * FROM rubros";
                    rubros.Clear();
                    rubros.Add(new Rubro { Id = 0, Nombre = "Seleccione" });
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    MySqlDataReader leerDatos = comando.ExecuteReader();
                    while (leerDatos.Read()) // lee y recorre cada fila leida de la DB
                    {
                        rubros.Add(new Rubro { Id = leerDatos.GetInt32("Id_Rubro"), Nombre = leerDatos.GetString("Nombre") });
                    }
                }
            }
            else
            {
                MessageBox.Show("La conexion no esta configurada correctamente.");
            }
            // Establecer el origen de datos del COMBOX
            comboBox1_Producto_Rubros.DataSource = rubros;
            // Especificar que propiedad se usara en el ComBox
            comboBox1_Producto_Rubros.DisplayMember = "Nombre";
            // Especificar que propiedad se usara como valor
            comboBox1_Producto_Rubros.ValueMember = "Id";

        }

        private void llenarcomboBox2_Productos_Proveedor() // LLenar combox
        {
            if (conexionDB != null)
            {
                //leer Datos de DB
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                {
                    String sql = "SELECT * FROM proveedores";
                    proveedores.Clear();
                    proveedores.Add(new Proveedor { Id = 0, Nombre = "Seleccione" });
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    MySqlDataReader leerDatos = comando.ExecuteReader();
                    while (leerDatos.Read()) // lee y recorre cada fila leida de la DB
                    {
                        proveedores.Add(new Proveedor { Id = leerDatos.GetInt32("Id_Proveedores"), Nombre = leerDatos.GetString("Nombre") });
                    }
                }
            }
            else
            {
                MessageBox.Show("La conexion no esta configurada correctamente.");
            }
            // Establecer el origen de datos del COMBOX
            comboBox2_Productos_Proveedor.DataSource = proveedores;
            // Especificar que propiedad se usara en el ComBox
            comboBox2_Productos_Proveedor.DisplayMember = "Nombre";
            // Especificar que propiedad se usara como valor
            comboBox2_Productos_Proveedor.ValueMember = "Id";

        }

        #endregion


        #region Usuarios
        private void button1_USUARIOS_Click_1(object sender, EventArgs e) //Boton Usuarios
        {
            ocultar_grupos();
            moduloActual = "usuarios";
            groupBox1_usuarios.Visible = true;
            groupBox1_usuarios.Size = new Size(700, 200);
            groupBox1_usuarios.Location = new Point(20, 75);
            CargarDatos("SELECT * FROM " + moduloActual);
            dataGridView1.Visible = true;
            dataGridView1.Location = new Point(20, 300);
            dataGridView1.Size = new Size(810, 210);

        }
        private void button1_Actualizar_Usuarios_Click(object sender, EventArgs e) // Actualizar Usuarios 
        {
            if ((indiceFila < 0 && textBox1_UsuarioNombres.Text == "") || (indiceFila > 0 && textBox1_UsuarioNombres.Text == "" && textBox1_idInvisible.Text == ""))
            {
                msje("no hay datos para actualizar");
                return;
            }
            // Crear un nuevo objeto con los datos de los Text box 
            int idReg = 0;
            if (indiceFila < 0) { idReg = usuarios.Count() + 1; }
            if (indiceFila > 0)
            {
                DataGridViewRow filaSelecionada = dataGridView1.Rows[indiceFila];
                idReg = Convert.ToInt32(filaSelecionada.Cells["Id"].Value);
            }
            Usuario nuevoUsuario = new Usuario
            {
                Id = idReg,
                Nombre = textBox1_UsuarioNombres.Text,
                Direccion = textBox2_UsuariosDireccion.Text,
                Email = textBox3_UsuariosEmail.Text,
                Telefono = Convert.ToInt32(textBox4_UsuariosTelefono.Text)
            };
            if (indiceFila < 0)
            { // si no hay fila seleccionada, agregar el nuevo usuario a la lista
                usuarios.Add(nuevoUsuario);
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                { // Insertar datos del nuevo usuario en DB
                    String consulta = "INSERT INTO usuarios (Nombre, Direccion, Email, Telefono) VALUES  ('" + nuevoUsuario.Nombre.Replace("'", "''") + "','" + nuevoUsuario.Direccion.Replace("'", "''") + "','" + nuevoUsuario.Email.Replace("'", "''") + "','" + nuevoUsuario.Telefono + "')";
                    ejecutarTransaccion(consulta);
                }
            }
            else
            { //actualizar los datos del usuario en la lista
                usuarios[indiceFila] = nuevoUsuario;
                //actualizar los datos del usuario en la DB
                string consulta = "UPDATE usuarios SET nombre = '" + nuevoUsuario.Nombre.Replace("'", "''") + "', direccion='" + nuevoUsuario.Direccion.Replace("'", "''") + "', email='" + nuevoUsuario.Email.Replace("'", "''") + "', telefono='" + nuevoUsuario.Telefono + "' WHERE Id_Usuarios=" + nuevoUsuario.Id;
                ejecutarTransaccion(consulta);
            }
            LimpiarDatos();
            ActualizarDataGrid();
            msje("Datos Actualizados");
            espera(1);

            // Habilitar nuevamente el DataGridView
            dataGridView1.Enabled = true;
            CargarDatos("SELECT * FROM " + moduloActual);
        }
        private void button2_Borrar_Usuarios_Click_1(object sender, EventArgs e) //Boton borrar usuarios
        {
            if (textBox1_idInvisible.Text == "")
            {
                MessageBox.Show("Debe seleccionar un item para eliminar");
                return;
            }
            int idfila = Convert.ToInt32(textBox1_idInvisible.Text);
            if (idfila > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar el item" + idfila + "?", "Confirmacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Obtener el valor de la columna que identifica el elemento (supongamos que es la columna 0)
                    int num = idfila;
                    // Buscar y eliminar el elemento en la fuente de datos (ejemplo con una lista)
                    Usuario elemento = usuarios.FirstOrDefault(x => x.Id == num);
                    if (elemento != null)
                    {
                        usuarios.Remove(elemento);
                        ejecutarTransaccion("DELETE FROM usuarios WHERE Id_Usuarios=" + elemento.Id);
                        LimpiarDatos();
                        ActualizarDataGrid();
                        msje("Elemento eliminado!");
                        espera(1);
                        CargarDatos("SELECT * FROM " + moduloActual);
                        dataGridView1.Enabled = true;
                    }
                }
            }


        }
        #endregion

        #region Rubros
        private void button2_RUBROS_Click_1(object sender, EventArgs e) //Boton Rubros
        {
            ocultar_grupos();
            moduloActual = "rubros";
            groupBox1_Rubros.Visible = true;
            groupBox1_Rubros.Location = new Point(20, 75);
            groupBox1_Rubros.Size = new Size(500, 120);
            CargarDatos("SELECT * FROM " + moduloActual);
            dataGridView1.Visible = true;
            dataGridView1.Size = new Size(370, 150);
            dataGridView1.Location = new Point(20, 210);
        }
        private void button1_RubrosActualizar_Click_1(object sender, EventArgs e) //Actualizar rubros
        {
            if ((indiceFila < 0 && textBox1_RubrosNombre.Text == "") || (indiceFila > 0 && textBox1_RubrosNombre.Text == "" && textBox1_idInvisible.Text == ""))
            {
                msje("No hay datos para actualizar");
                return;
            }
            // Crear un nuevo objeto con los datos de los Text box 
            int idReg = 0;
            if (indiceFila < 0) { idReg = rubros.Count() + 1; }
            if (indiceFila > 0)
            {
                DataGridViewRow filaSelecionada = dataGridView1.Rows[indiceFila];
                idReg = Convert.ToInt32(filaSelecionada.Cells["Id"].Value);
            }
            Rubro nuevoRubro = new Rubro
            {
                Id = idReg,
                Nombre = textBox1_RubrosNombre.Text,
            };
            if (indiceFila < 0)
            { // si no hay fila seleccionada, agregar el nuevo rubro a la lista
                rubros.Add(nuevoRubro);
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                { // Insertar datos del nuevo usuario en DB
                    String consulta = "INSERT INTO rubros (Nombre) VALUES  ('" + nuevoRubro.Nombre.Replace("'", "''") + "')";
                    ejecutarTransaccion(consulta);
                }
            }
            else
            { //actualizar los datos en la lista rubros
                rubros[indiceFila] = nuevoRubro;
                //actualizar los datos de rubros en Base de datos
                string consulta = "UPDATE rubros SET nombre = '" + nuevoRubro.Nombre.Replace("'", "''") + "' WHERE Id_Rubro=" + nuevoRubro.Id;
                ejecutarTransaccion(consulta);
            }
            LimpiarDatos();
            ActualizarDataGrid();
            msje("Datos Actualizados");
            espera(1);

            // Habilitar nuevamente el DataGridView
            dataGridView1.Enabled = true;
            CargarDatos("SELECT * FROM " + moduloActual);
        }
        private void button2_RubrosBorrar_Click(object sender, EventArgs e) // Borrar rubros
        {

            if (textBox1_idInvisible.Text == "")
            {
                MessageBox.Show("Debe seleccionar un item para eliminar");
                return;
            }
            int idfila = Convert.ToInt32(textBox1_idInvisible.Text);
            if (idfila > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar el item" + idfila + "?", "Confirmacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Obtener el valor de la columna que identifica el elemento (supongamos que es la columna 0)
                    int num = idfila;
                    // Buscar y eliminar el elemento en la fuente de datos (ejemplo con una lista)
                    Rubro elemento = rubros.FirstOrDefault(x => x.Id == num);
                    if (elemento != null)
                    {
                        rubros.Remove(elemento);
                        ejecutarTransaccion("DELETE FROM rubros WHERE Id_Rubro=" + elemento.Id);
                        LimpiarDatos();
                        ActualizarDataGrid();
                        msje("Elemento eliminado!");
                        espera(1);
                        CargarDatos("SELECT * FROM " + moduloActual);
                        dataGridView1.Enabled = true;
                    }
                }
            }
        }

        #endregion

        #region Proveedores
        private void button3_PROVEEDORES_Click_1(object sender, EventArgs e) //boton proveedores
        {
            ocultar_grupos();
            moduloActual = "proveedores";
            groupBox1_Proveedores.Visible = true;
            groupBox1_Proveedores.Location = new Point(20, 75);
            groupBox1_Proveedores.Size = new Size(480, 120);
            CargarDatos("SELECT * FROM " + moduloActual);
            dataGridView1.Visible = true;
            dataGridView1.Size = new Size(345, 150);
            dataGridView1.Location = new Point(20, 225);
        }
        private void button1_ProveedoresActualizar_Click(object sender, EventArgs e) // Actualizar proveedores
        {
            if ((indiceFila < 0 && textBox1_Proveedores.Text == "") || (indiceFila > 0 && textBox1_Proveedores.Text == "" && textBox1_idInvisible.Text == ""))
            {
                msje("No hay datos para actualizar");
                return;
            }
            // Crear un nuevo objeto con los datos de los Text box 
            int idReg = 0;
            if (indiceFila < 0) { idReg = proveedores.Count() + 1; }
            if (indiceFila > 0)
            {
                DataGridViewRow filaSelecionada = dataGridView1.Rows[indiceFila];
                idReg = Convert.ToInt32(filaSelecionada.Cells["Id"].Value);
            }
            Proveedor nuevoProveedor = new Proveedor
            {
                Id = idReg,
                Nombre = textBox1_Proveedores.Text,
            };
            if (indiceFila < 0)
            { // si no hay fila seleccionada, agregar el nuevo rubro a la lista
                proveedores.Add(nuevoProveedor);
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                { // Insertar datos del nuevo usuario en DB
                    String consulta = "INSERT INTO proveedores (Nombre) VALUES  ('" + nuevoProveedor.Nombre.Replace("'", "''") + "')";
                    ejecutarTransaccion(consulta);
                }
            }
            else
            { //actualizar los datos en la lista rubros
                proveedores[indiceFila] = nuevoProveedor;
                //actualizar los datos de rubros en Base de datos
                string consulta = "UPDATE proveedores SET nombre = '" + nuevoProveedor.Nombre.Replace("'", "''") + "' WHERE Id_Proveedores=" + nuevoProveedor.Id;
                ejecutarTransaccion(consulta);
            }
            LimpiarDatos();
            ActualizarDataGrid();
            msje("Datos Actualizados");
            espera(1);

            // Habilitar nuevamente el DataGridView
            dataGridView1.Enabled = true;
            CargarDatos("SELECT * FROM " + moduloActual);
        }
        private void button2_ProveedoresBorrar_Click(object sender, EventArgs e) // Borrar proveedores 
        {

            if (textBox1_idInvisible.Text == "")
            {
                MessageBox.Show("Debe seleccionar un item para eliminar");
                return;
            }
            int idfila = Convert.ToInt32(textBox1_idInvisible.Text);
            if (idfila > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar el item" + idfila + "?", "Confirmacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Obtener el valor de la columna que identifica el elemento (supongamos que es la columna 0)
                    int num = idfila;
                    // Buscar y eliminar el elemento en la fuente de datos (ejemplo con una lista)
                    Proveedor elemento = proveedores.FirstOrDefault(x => x.Id == num);
                    if (elemento != null)
                    {
                        proveedores.Remove(elemento);
                        ejecutarTransaccion("DELETE FROM proveedores WHERE Id_Proveedores=" + elemento.Id);
                        LimpiarDatos();
                        ActualizarDataGrid();
                        msje("Elemento eliminado!");
                        espera(1);
                        CargarDatos("SELECT * FROM " + moduloActual);
                        dataGridView1.Enabled = true;
                    }
                }
            }
        }

        #endregion

        #region Productos

        private void button4_PRODUCTOS_Click(object sender, EventArgs e) // Boton Productos
        {
            ocultar_grupos();
            moduloActual = "productos";
            groupBox1_Productos.Visible = true;
            groupBox1_Productos.Location = new Point(20, 75);
            groupBox1_Productos.Size = new Size(600, 181);
            CargarDatos("SELECT p.*, r.Nombre AS rubro, pr.Nombre AS proveedor " + "FROM productos p " + "INNER JOIN rubros r ON p.Id_Rubro = r.Id_Rubro " + "INNER JOIN proveedores pr ON p.Id_Proveedores = pr.Id_Proveedores");
            llenarcomboBox1_Producto_Rubros();
            llenarcomboBox2_Productos_Proveedor();
            dataGridView1.Visible = true;
            dataGridView1.Location = new Point(20, 280);
            dataGridView1.Size = new Size(745, 125);
        }

        private void button2_ActualizarProductos_Click_1(object sender, EventArgs e) // Actualizar productos
        {
            if ((indiceFila < 0 && textBox1_ProductoNombre.Text == "") || (indiceFila > 0 && textBox1_ProductoNombre.Text == "" && textBox1_idInvisible.Text == ""))
            {
                msje("no hay datos para actualizar");
                return;
            }
            //verificar datos antes de continuar (combo rubro y proveedor)
            if (Convert.ToInt16(comboBox1_Producto_Rubros.SelectedValue) <= 0 || Convert.ToInt16(comboBox2_Productos_Proveedor.SelectedValue) <= 0)
            {
                msje("Complete todos los datos por favor");
                return;
            }
            // Crear un nuevo objeto con los datos de los Text box 
            int idReg = 0;
            if (indiceFila < 0) { idReg = productos.Count() + 1; }
            if (indiceFila > 0)
            {
                DataGridViewRow filaSelecionada = dataGridView1.Rows[indiceFila];
                idReg = Convert.ToInt32(filaSelecionada.Cells["Id"].Value);
            }
            Producto nuevoProducto = new Producto //Verificar
            {
                Id = idReg,
                Nombre = textBox1_ProductoNombre.Text,
                Id_Rubro = Convert.ToInt32(comboBox1_Producto_Rubros.SelectedValue),
                Id_Proveedor = Convert.ToInt32(comboBox2_Productos_Proveedor.SelectedValue),
                Precio = Convert.ToDouble(textBox3_PrecioProductos.Text),
                Costo = Convert.ToDouble(textBox2_CostoProducto.Text),
            };
            if (indiceFila < 0)
            { // si no hay fila seleccionada, agregar el nuevo usuario a la lista
                productos.Add(nuevoProducto);
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                { // Insertar datos del nuevo usuario en DB
                    String consulta = "INSERT INTO productos (Nombre, Costo, Precio, Id_Rubro, Id_Proveedores ) VALUES  ('" + nuevoProducto.Nombre.Replace("'", "''") + "','" + nuevoProducto.Costo + "','" + nuevoProducto.Precio + "','" + nuevoProducto.Id_Rubro + "','" + nuevoProducto.Id_Proveedor + "')";
                    ejecutarTransaccion(consulta);
                }
            }
            else
            { //actualizar los datos del producto en la lista
                productos[indiceFila] = nuevoProducto;
                //actualizar los datos del usuario en la DB
                string consulta = "UPDATE productos SET Nombre = '" + nuevoProducto.Nombre.Replace("'", "''") + "', Costo = '" + nuevoProducto.Costo + "', Precio = '" + nuevoProducto.Precio + "', Id_Rubro = '" + nuevoProducto.Id_Rubro + "', Id_Proveedores = '" + nuevoProducto.Id_Proveedor + "' WHERE Id_Productos = " + nuevoProducto.Id;
                ejecutarTransaccion(consulta);
            }
            LimpiarDatos();
            ActualizarDataGrid();
            msje("Datos Actualizados");
            espera(1);

            // Habilitar nuevamente el DataGridView
            dataGridView1.Enabled = true;
            CargarDatos("SELECT p.*, r.Nombre AS rubro, pr.Nombre AS proveedor " + "FROM productos p " + "INNER JOIN rubros r ON p.Id_Rubro = r.Id_Rubro " + "INNER JOIN proveedores pr ON p.Id_Proveedores = pr.Id_Proveedores");
        }

        private void button1_BorrarProductos_Click(object sender, EventArgs e) //Borrar Productos
        {
            if (textBox1_idInvisible.Text == "")
            {
                MessageBox.Show("Debe seleccionar un item para eliminar");
                return;
            }
            int idfila = Convert.ToInt32(textBox1_idInvisible.Text);
            if (idfila > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar el item" + idfila + "?", "Confirmacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Obtener el valor de la columna que identifica el elemento (supongamos que es la columna 0)
                    int num = idfila;
                    // Buscar y eliminar el elemento en la fuente de datos (ejemplo con una lista)
                    Producto elemento = productos.FirstOrDefault(x => x.Id == num);
                    if (elemento != null)
                    {
                        productos.Remove(elemento);

                        if (ejecutarTransaccion("DELETE FROM productos WHERE Id_Productos=" + elemento.Id))
                        {
                            msje("Elemento eliminado!");
                        }
                        LimpiarDatos();
                        ActualizarDataGrid();
                        espera(1);
                        CargarDatos("SELECT p.*, r.Nombre AS rubro, pr.Nombre AS proveedor " + "FROM productos p " + "INNER JOIN rubros r ON p.Id_Rubro = r.Id_Rubro " + "INNER JOIN proveedores pr ON p.Id_Proveedores = pr.Id_Proveedores");
                        dataGridView1.Enabled = true;
                    }
                }
            }
        }

        #endregion

        #region Pedidos

        private void button5_PEDIDOS_Click(object sender, EventArgs e) // Boton pedidos 
        {
            ocultar_grupos();
            moduloActual = "pedidos";
            groupBox1_Pedidos.Visible = true;
            groupBox1_Pedidos.Location = new Point(20,75);
            groupBox1_Pedidos.Visible = true;
            llenar_combo_Clientes();
            groupBox1_Pedidos.Size = new Size(399, 120);
            dataGridView1.Size = new Size(400, 216);
            dataGridView1.Location = new Point(20, 225);

            CargarDatos("SELECT p.*, c.nombre as usuario FROM pedidos p INNER JOIN usuarios c ON c.Id_Usuarios = p.Id_Usuario ORDER BY Id_Pedidos DESC"); //Volver a ver el ON******
            dataGridView1.Visible = true;
            pedidos_items.Clear();
        }
        private void button1_AgregarPedido_Click(object sender, EventArgs e) // Boton agregar pedidos
        {
            if (Convert.ToInt16(comboBox1_Pedidos.SelectedValue) <= 0)
            {
                msje("Seleccione usuario para el Nuevo Pedido");
                return;
            }
            // Crear un nuevo objeto con los datos de los TextBox
            int idReg = 0;
            button1_AgregarPedido.Enabled = false;
            textBox1_TotalPedido.ReadOnly = true;
            comboBox1_Pedidos.Enabled = false;
            if (indiceFila < 0) { idReg = pedidos.Count() + 1; }

            Pedido nuevo = new Pedido
            {
                Id = idReg,
                Id_Usuario = Convert.ToInt32(comboBox1_Pedidos.SelectedValue),
                Fecha = DateTime.Now,
                Total = 0
            };
            if (indiceFila < 0)
            { //Si no hay fila seleccionada, agregar el nuevo pedido a lista
                pedidos.Add(nuevo);
                using (MySqlConnection conexion = conexionDB.ObtenerConexion())
                { //Insertar datos del nuevo usuario en la DB
                    string consulta = "INSERT INTO pedidos (Id_Usuario,total) VALUES ('" + nuevo.Id_Usuario + "','" + nuevo.Total + "')";
                    if (ejecutarTransaccion(consulta)) { msje("Datos Agregados en:" + moduloActual); }
                }

            }
            button1_AgregarPedido.Visible = false;
            button3_PedidosCerrar.Visible = true; //Hace Visible cerrar Pedidos

            //LimpiarDatos();

            ActualizarDataGrid();
            groupBox1_ItemPedido.Location = new Point(450,75 );
            espera(1);
            CargarDatos("SELECT p.*, c.nombre as usuario FROM pedidos p INNER JOIN usuarios c ON c.Id_Usuarios = p.Id_Usuario ORDER BY Id_Pedidos DESC");
            groupBox1_ItemPedido.Text = "Items Pedido N°[" + pedidoEnCurso + "]";
            llenar_combo_Productos();
            groupBox1_ItemPedido.Visible = true;
            dataGridView1.Enabled = false;
            dataGridView2.Visible = true;
            dataGridView2.Location = new Point(575,225);
            dataGridView2.Size = new Size(600,216 );
            pedidos_items.Clear();
        }

        private void comboBox2_PedidoItem_SelectedIndexChanged(object sender, EventArgs e) // Metedo seleecionar un producto y ver precio
        {
            Decimal selectedValue = 0;
            if (Decimal.TryParse(comboBox2_PedidoItem.SelectedValue.ToString(), out selectedValue))
            {
                textBox2_ItemPrecio.Text = BuscarPrecioProducto(selectedValue);
            }
            else { }
        }
 
        private void button3_PedidosCerrar_Click(object sender, EventArgs e)
        {
            if (totalGralPedido <= 0) { msje("verifique el total precio pedido"); return; }
            ActualizartotalPedido(pedidoEnCurso, totalGralPedido);
            pedidoEnCurso = 0;
            totalGralPedido = 0;
            textBox1_TotalPedido.Text = "0.00";
            LimpiarDatos();
            dataGridView2.Visible = false;
            groupBox1_ItemPedido.Visible = false;
            CargarDatos("select p.*, c.nombre as usuario from pedidos p inner join usuarios c on c.Id_Usuarios = P.Id_Usuario Order by Id_Pedidos desc ");
        }
        
        private void button2_AgrgarItem_Click(object sender, EventArgs e) // agregar item al pedido
        {
            if (pedidoEnCurso <= 0) { msje("verifique pedido en curso"); return; }
            if (Convert.ToInt32(textBox1_ItemCantidad.Text) <= 0 || Convert.ToDouble(textBox2_ItemPrecio.Text) <= 0)
            {
                msje("verifique precio y cantidad"); return;
            }
            using (MySqlConnection conexion = conexionDB.ObtenerConexion())
            {
                string consulta = "insert into pedidos_items (Id_Pedidos , Id_Producto , cantidad , precio ) values ('" + pedidoEnCurso + "','" + comboBox2_PedidoItem.SelectedValue + "','" + textBox1_ItemCantidad.Text + "','" + textBox2_ItemPrecio.Text + "')";
                ejecutarTransaccion(consulta);
            }
            CargarItems("select it.*, p.nombre as producto from pedidos_items it inner join productos p on p.Id_Productos = it.Id_Producto where Id_Pedidos =" + pedidoEnCurso);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = pedidos_items;
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 100;
            //dataGridView2.Columns[2].Visible=false;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 100;
            dataGridView2.Refresh();
            totalGralPedido += Convert.ToDouble(textBox2_ItemPrecio.Text) * Convert.ToDouble(textBox1_ItemCantidad.Text);
            textBox1_TotalPedido.Text = totalGralPedido.ToString();
            textBox1_ItemCantidad.Text = "1";
            textBox2_ItemPrecio.Text = "0.00";
        }
        
        #endregion


        // FUNCIONALIDAD BORRAR ITEM DE LA GRILLA PEDIDOS:
        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //Obtener la fila selecionada y mostrarla en texbox
                DataGridViewRow filaSeleccionada = dataGridView2.Rows[e.RowIndex];

                //Obtener los valores de las celdas asignarlos a los texBox:
                int num = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                double pre_item = Convert.ToDouble(filaSeleccionada.Cells["precio"].Value);
                int cant_item = Convert.ToInt32(filaSeleccionada.Cells["cantidad"].Value);

                DialogResult resultado = MessageBox.Show(" ¿Desea eliminar el item " + num + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    totalGralPedido -= (pre_item * cant_item);
                    textBox1_TotalPedido.Text = totalGralPedido.ToString();
                    ejecutarTransaccion("DELETE FROM pedidos_items WHERE Id_Pedidos_Items= " + num);
                    msje("Item Eliminado !");

                    //Recargo la grilla luego de la eliminacion del items:
                    CargarItems("select it.*, p.nombre as producto from pedidos_items it inner join productos p on p.Id_Productos = it.Id_Producto where Id_Pedidos = " + pedidoEnCurso);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = pedidos_items;
                    dataGridView2.Columns[0].Width = 30;
                    dataGridView2.Columns[1].Width = 60;
                    dataGridView2.Columns[2].Width = 60;
                    dataGridView2.Columns[3].Width = 50;
                    dataGridView2.Columns[4].Width = 45;
                    dataGridView2.Refresh();
                }
            }
        }
        
        private void button1_SALIR_Click(object sender, EventArgs e) //BOTON SALIR
        {
            if (totalGralPedido > 0 || pedidoEnCurso > 0)
            {
                msje("Verifique, tiene pedido en curso!");
                return;
            }

            this.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Pedidos_Enter(object sender, EventArgs e)
        {

        }
    }
}
#region Clases
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public int Telefono { get; set; }
}
public class Rubro
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}
public class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Id_Rubro { get; set; }
    public int Id_Proveedor { get; set; }
    public double Precio { get; set; }
    public double Costo { get; set; }
    public string NombreRubro { get; set; }
    public string NombreProveedor { get; set; }
}
public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha {get; set;}
    public int Id_Usuario { get; set; }
    public double Total { get; set; }
    public string NombreUsuario { get; set; }
}
public class Pedido_Item
{
    public int Id { get; set; } 
    public int Id_Pedido { get; set; }
    public int Id_Producto { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set;}   
    public string NombreProducto { get; set; }  
}

    public class ConexionDB
{
    private string cadenaConexion;
    public ConexionDB(string servidor, string usuario, string password, string baseDatos)
    {
        // Agregamos los espacios y el delimitador adecuado entre cada parámetro
        cadenaConexion = "server=" + servidor + ";user=" + usuario + ";password=" + password + ";database=" + baseDatos + ";";
    }

    public MySqlConnection ObtenerConexion()
    {
        return new MySqlConnection(cadenaConexion);
    }
}
#endregion