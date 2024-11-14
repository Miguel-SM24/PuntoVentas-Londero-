namespace PuntoVentas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1_USUARIOS = new System.Windows.Forms.Button();
            this.button2_RUBROS = new System.Windows.Forms.Button();
            this.button3_PROVEEDORES = new System.Windows.Forms.Button();
            this.button4_PRODUCTOS = new System.Windows.Forms.Button();
            this.button5_PEDIDOS = new System.Windows.Forms.Button();
            this.groupBox1_usuarios = new System.Windows.Forms.GroupBox();
            this.button2_Borrar_Usuarios = new System.Windows.Forms.Button();
            this.button1_Actualizar_Usuarios = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4_UsuariosTelefono = new System.Windows.Forms.TextBox();
            this.textBox3_UsuariosEmail = new System.Windows.Forms.TextBox();
            this.textBox2_UsuariosDireccion = new System.Windows.Forms.TextBox();
            this.textBox1_UsuarioNombres = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1_Rubros = new System.Windows.Forms.GroupBox();
            this.button2_RubrosBorrar = new System.Windows.Forms.Button();
            this.button1_RubrosActualizar = new System.Windows.Forms.Button();
            this.textBox1_RubrosNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1_idInvisible = new System.Windows.Forms.TextBox();
            this.mensaje = new System.Windows.Forms.Label();
            this.groupBox1_Proveedores = new System.Windows.Forms.GroupBox();
            this.button2_ProveedoresBorrar = new System.Windows.Forms.Button();
            this.button1_ProveedoresActualizar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1_Proveedores = new System.Windows.Forms.TextBox();
            this.groupBox1_Productos = new System.Windows.Forms.GroupBox();
            this.button2_ActualizarProductos = new System.Windows.Forms.Button();
            this.button1_BorrarProductos = new System.Windows.Forms.Button();
            this.comboBox2_Productos_Proveedor = new System.Windows.Forms.ComboBox();
            this.comboBox1_Producto_Rubros = new System.Windows.Forms.ComboBox();
            this.textBox3_PrecioProductos = new System.Windows.Forms.TextBox();
            this.textBox2_CostoProducto = new System.Windows.Forms.TextBox();
            this.textBox1_ProductoNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1_Pedidos = new System.Windows.Forms.GroupBox();
            this.textBox1_TotalPedido = new System.Windows.Forms.TextBox();
            this.button1_AgregarPedido = new System.Windows.Forms.Button();
            this.comboBox1_Pedidos = new System.Windows.Forms.ComboBox();
            this.button3_PedidosCerrar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1_ItemPedido = new System.Windows.Forms.GroupBox();
            this.textBox3_ItemDTO = new System.Windows.Forms.TextBox();
            this.textBox2_ItemPrecio = new System.Windows.Forms.TextBox();
            this.textBox1_ItemCantidad = new System.Windows.Forms.TextBox();
            this.button2_AgrgarItem = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox2_PedidoItem = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1_SALIR = new System.Windows.Forms.Button();
            this.groupBox1_usuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1_Rubros.SuspendLayout();
            this.groupBox1_Proveedores.SuspendLayout();
            this.groupBox1_Productos.SuspendLayout();
            this.groupBox1_Pedidos.SuspendLayout();
            this.groupBox1_ItemPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1_USUARIOS
            // 
            this.button1_USUARIOS.Location = new System.Drawing.Point(28, 12);
            this.button1_USUARIOS.Name = "button1_USUARIOS";
            this.button1_USUARIOS.Size = new System.Drawing.Size(75, 36);
            this.button1_USUARIOS.TabIndex = 0;
            this.button1_USUARIOS.Text = "USUARIOS";
            this.button1_USUARIOS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1_USUARIOS.UseVisualStyleBackColor = true;
            this.button1_USUARIOS.Click += new System.EventHandler(this.button1_USUARIOS_Click_1);
            // 
            // button2_RUBROS
            // 
            this.button2_RUBROS.Location = new System.Drawing.Point(121, 12);
            this.button2_RUBROS.Name = "button2_RUBROS";
            this.button2_RUBROS.Size = new System.Drawing.Size(89, 36);
            this.button2_RUBROS.TabIndex = 1;
            this.button2_RUBROS.Text = "RUBROS";
            this.button2_RUBROS.UseVisualStyleBackColor = true;
            this.button2_RUBROS.Click += new System.EventHandler(this.button2_RUBROS_Click_1);
            // 
            // button3_PROVEEDORES
            // 
            this.button3_PROVEEDORES.Location = new System.Drawing.Point(226, 12);
            this.button3_PROVEEDORES.Name = "button3_PROVEEDORES";
            this.button3_PROVEEDORES.Size = new System.Drawing.Size(101, 36);
            this.button3_PROVEEDORES.TabIndex = 2;
            this.button3_PROVEEDORES.Text = "PROVEEDORES";
            this.button3_PROVEEDORES.UseVisualStyleBackColor = true;
            this.button3_PROVEEDORES.Click += new System.EventHandler(this.button3_PROVEEDORES_Click_1);
            // 
            // button4_PRODUCTOS
            // 
            this.button4_PRODUCTOS.Location = new System.Drawing.Point(356, 12);
            this.button4_PRODUCTOS.Name = "button4_PRODUCTOS";
            this.button4_PRODUCTOS.Size = new System.Drawing.Size(97, 36);
            this.button4_PRODUCTOS.TabIndex = 3;
            this.button4_PRODUCTOS.Text = "PRODUCTOS";
            this.button4_PRODUCTOS.UseVisualStyleBackColor = true;
            this.button4_PRODUCTOS.Click += new System.EventHandler(this.button4_PRODUCTOS_Click);
            // 
            // button5_PEDIDOS
            // 
            this.button5_PEDIDOS.Location = new System.Drawing.Point(469, 12);
            this.button5_PEDIDOS.Name = "button5_PEDIDOS";
            this.button5_PEDIDOS.Size = new System.Drawing.Size(89, 36);
            this.button5_PEDIDOS.TabIndex = 4;
            this.button5_PEDIDOS.Text = "PEDIDOS";
            this.button5_PEDIDOS.UseVisualStyleBackColor = true;
            this.button5_PEDIDOS.Click += new System.EventHandler(this.button5_PEDIDOS_Click);
            // 
            // groupBox1_usuarios
            // 
            this.groupBox1_usuarios.Controls.Add(this.button2_Borrar_Usuarios);
            this.groupBox1_usuarios.Controls.Add(this.button1_Actualizar_Usuarios);
            this.groupBox1_usuarios.Controls.Add(this.label4);
            this.groupBox1_usuarios.Controls.Add(this.label3);
            this.groupBox1_usuarios.Controls.Add(this.label2);
            this.groupBox1_usuarios.Controls.Add(this.label1);
            this.groupBox1_usuarios.Controls.Add(this.textBox4_UsuariosTelefono);
            this.groupBox1_usuarios.Controls.Add(this.textBox3_UsuariosEmail);
            this.groupBox1_usuarios.Controls.Add(this.textBox2_UsuariosDireccion);
            this.groupBox1_usuarios.Controls.Add(this.textBox1_UsuarioNombres);
            this.groupBox1_usuarios.Location = new System.Drawing.Point(793, 47);
            this.groupBox1_usuarios.Name = "groupBox1_usuarios";
            this.groupBox1_usuarios.Size = new System.Drawing.Size(91, 36);
            this.groupBox1_usuarios.TabIndex = 5;
            this.groupBox1_usuarios.TabStop = false;
            this.groupBox1_usuarios.Text = "usuarios";
            this.groupBox1_usuarios.Visible = false;
            // 
            // button2_Borrar_Usuarios
            // 
            this.button2_Borrar_Usuarios.Location = new System.Drawing.Point(535, 79);
            this.button2_Borrar_Usuarios.Name = "button2_Borrar_Usuarios";
            this.button2_Borrar_Usuarios.Size = new System.Drawing.Size(102, 32);
            this.button2_Borrar_Usuarios.TabIndex = 9;
            this.button2_Borrar_Usuarios.Text = "BORRAR";
            this.button2_Borrar_Usuarios.UseVisualStyleBackColor = true;
            this.button2_Borrar_Usuarios.Click += new System.EventHandler(this.button2_Borrar_Usuarios_Click_1);
            // 
            // button1_Actualizar_Usuarios
            // 
            this.button1_Actualizar_Usuarios.Location = new System.Drawing.Point(535, 38);
            this.button1_Actualizar_Usuarios.Name = "button1_Actualizar_Usuarios";
            this.button1_Actualizar_Usuarios.Size = new System.Drawing.Size(102, 32);
            this.button1_Actualizar_Usuarios.TabIndex = 8;
            this.button1_Actualizar_Usuarios.Text = "ACUTALIZAR";
            this.button1_Actualizar_Usuarios.UseVisualStyleBackColor = true;
            this.button1_Actualizar_Usuarios.Click += new System.EventHandler(this.button1_Actualizar_Usuarios_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TELEFONO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "EMAIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DIRECCION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE";
            // 
            // textBox4_UsuariosTelefono
            // 
            this.textBox4_UsuariosTelefono.Location = new System.Drawing.Point(120, 163);
            this.textBox4_UsuariosTelefono.Name = "textBox4_UsuariosTelefono";
            this.textBox4_UsuariosTelefono.Size = new System.Drawing.Size(318, 20);
            this.textBox4_UsuariosTelefono.TabIndex = 3;
            // 
            // textBox3_UsuariosEmail
            // 
            this.textBox3_UsuariosEmail.Location = new System.Drawing.Point(120, 117);
            this.textBox3_UsuariosEmail.Name = "textBox3_UsuariosEmail";
            this.textBox3_UsuariosEmail.Size = new System.Drawing.Size(318, 20);
            this.textBox3_UsuariosEmail.TabIndex = 2;
            // 
            // textBox2_UsuariosDireccion
            // 
            this.textBox2_UsuariosDireccion.Location = new System.Drawing.Point(120, 72);
            this.textBox2_UsuariosDireccion.Name = "textBox2_UsuariosDireccion";
            this.textBox2_UsuariosDireccion.Size = new System.Drawing.Size(318, 20);
            this.textBox2_UsuariosDireccion.TabIndex = 1;
            // 
            // textBox1_UsuarioNombres
            // 
            this.textBox1_UsuarioNombres.Location = new System.Drawing.Point(120, 31);
            this.textBox1_UsuarioNombres.Name = "textBox1_UsuarioNombres";
            this.textBox1_UsuarioNombres.Size = new System.Drawing.Size(318, 20);
            this.textBox1_UsuarioNombres.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 257);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(606, 153);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1_Rubros
            // 
            this.groupBox1_Rubros.Controls.Add(this.button2_RubrosBorrar);
            this.groupBox1_Rubros.Controls.Add(this.button1_RubrosActualizar);
            this.groupBox1_Rubros.Controls.Add(this.textBox1_RubrosNombre);
            this.groupBox1_Rubros.Controls.Add(this.label5);
            this.groupBox1_Rubros.Location = new System.Drawing.Point(690, 41);
            this.groupBox1_Rubros.Name = "groupBox1_Rubros";
            this.groupBox1_Rubros.Size = new System.Drawing.Size(60, 26);
            this.groupBox1_Rubros.TabIndex = 7;
            this.groupBox1_Rubros.TabStop = false;
            this.groupBox1_Rubros.Text = "Rubros";
            this.groupBox1_Rubros.Visible = false;
            // 
            // button2_RubrosBorrar
            // 
            this.button2_RubrosBorrar.Location = new System.Drawing.Point(271, 62);
            this.button2_RubrosBorrar.Name = "button2_RubrosBorrar";
            this.button2_RubrosBorrar.Size = new System.Drawing.Size(102, 25);
            this.button2_RubrosBorrar.TabIndex = 3;
            this.button2_RubrosBorrar.Text = "BORRAR";
            this.button2_RubrosBorrar.UseVisualStyleBackColor = true;
            this.button2_RubrosBorrar.Click += new System.EventHandler(this.button2_RubrosBorrar_Click);
            // 
            // button1_RubrosActualizar
            // 
            this.button1_RubrosActualizar.Location = new System.Drawing.Point(271, 32);
            this.button1_RubrosActualizar.Name = "button1_RubrosActualizar";
            this.button1_RubrosActualizar.Size = new System.Drawing.Size(102, 24);
            this.button1_RubrosActualizar.TabIndex = 2;
            this.button1_RubrosActualizar.Text = "ACTUALIZAR";
            this.button1_RubrosActualizar.UseVisualStyleBackColor = true;
            this.button1_RubrosActualizar.Click += new System.EventHandler(this.button1_RubrosActualizar_Click_1);
            // 
            // textBox1_RubrosNombre
            // 
            this.textBox1_RubrosNombre.Location = new System.Drawing.Point(28, 54);
            this.textBox1_RubrosNombre.Name = "textBox1_RubrosNombre";
            this.textBox1_RubrosNombre.Size = new System.Drawing.Size(216, 20);
            this.textBox1_RubrosNombre.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "NOMBRE";
            // 
            // textBox1_idInvisible
            // 
            this.textBox1_idInvisible.BackColor = System.Drawing.Color.Lime;
            this.textBox1_idInvisible.Location = new System.Drawing.Point(598, 28);
            this.textBox1_idInvisible.Name = "textBox1_idInvisible";
            this.textBox1_idInvisible.Size = new System.Drawing.Size(29, 20);
            this.textBox1_idInvisible.TabIndex = 10;
            this.textBox1_idInvisible.Visible = false;
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.Location = new System.Drawing.Point(223, 51);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(47, 13);
            this.mensaje.TabIndex = 11;
            this.mensaje.Text = "Mensaje";
            this.mensaje.Visible = false;
            // 
            // groupBox1_Proveedores
            // 
            this.groupBox1_Proveedores.Controls.Add(this.button2_ProveedoresBorrar);
            this.groupBox1_Proveedores.Controls.Add(this.button1_ProveedoresActualizar);
            this.groupBox1_Proveedores.Controls.Add(this.label6);
            this.groupBox1_Proveedores.Controls.Add(this.textBox1_Proveedores);
            this.groupBox1_Proveedores.Location = new System.Drawing.Point(793, 12);
            this.groupBox1_Proveedores.Name = "groupBox1_Proveedores";
            this.groupBox1_Proveedores.Size = new System.Drawing.Size(121, 21);
            this.groupBox1_Proveedores.TabIndex = 12;
            this.groupBox1_Proveedores.TabStop = false;
            this.groupBox1_Proveedores.Text = "Proveedores";
            this.groupBox1_Proveedores.Visible = false;
            // 
            // button2_ProveedoresBorrar
            // 
            this.button2_ProveedoresBorrar.Location = new System.Drawing.Point(332, 73);
            this.button2_ProveedoresBorrar.Name = "button2_ProveedoresBorrar";
            this.button2_ProveedoresBorrar.Size = new System.Drawing.Size(102, 27);
            this.button2_ProveedoresBorrar.TabIndex = 5;
            this.button2_ProveedoresBorrar.Text = "BORRAR";
            this.button2_ProveedoresBorrar.UseVisualStyleBackColor = true;
            this.button2_ProveedoresBorrar.Click += new System.EventHandler(this.button2_ProveedoresBorrar_Click);
            // 
            // button1_ProveedoresActualizar
            // 
            this.button1_ProveedoresActualizar.Location = new System.Drawing.Point(332, 36);
            this.button1_ProveedoresActualizar.Name = "button1_ProveedoresActualizar";
            this.button1_ProveedoresActualizar.Size = new System.Drawing.Size(102, 26);
            this.button1_ProveedoresActualizar.TabIndex = 4;
            this.button1_ProveedoresActualizar.Text = "ACTUALIZAR";
            this.button1_ProveedoresActualizar.UseVisualStyleBackColor = true;
            this.button1_ProveedoresActualizar.Click += new System.EventHandler(this.button1_ProveedoresActualizar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "NOMBRE";
            // 
            // textBox1_Proveedores
            // 
            this.textBox1_Proveedores.Location = new System.Drawing.Point(83, 48);
            this.textBox1_Proveedores.Name = "textBox1_Proveedores";
            this.textBox1_Proveedores.Size = new System.Drawing.Size(208, 20);
            this.textBox1_Proveedores.TabIndex = 2;
            // 
            // groupBox1_Productos
            // 
            this.groupBox1_Productos.Controls.Add(this.button2_ActualizarProductos);
            this.groupBox1_Productos.Controls.Add(this.button1_BorrarProductos);
            this.groupBox1_Productos.Controls.Add(this.comboBox2_Productos_Proveedor);
            this.groupBox1_Productos.Controls.Add(this.comboBox1_Producto_Rubros);
            this.groupBox1_Productos.Controls.Add(this.textBox3_PrecioProductos);
            this.groupBox1_Productos.Controls.Add(this.textBox2_CostoProducto);
            this.groupBox1_Productos.Controls.Add(this.textBox1_ProductoNombre);
            this.groupBox1_Productos.Controls.Add(this.label11);
            this.groupBox1_Productos.Controls.Add(this.label10);
            this.groupBox1_Productos.Controls.Add(this.label9);
            this.groupBox1_Productos.Controls.Add(this.label8);
            this.groupBox1_Productos.Controls.Add(this.label7);
            this.groupBox1_Productos.Location = new System.Drawing.Point(688, 12);
            this.groupBox1_Productos.Name = "groupBox1_Productos";
            this.groupBox1_Productos.Size = new System.Drawing.Size(81, 21);
            this.groupBox1_Productos.TabIndex = 13;
            this.groupBox1_Productos.TabStop = false;
            this.groupBox1_Productos.Text = "Productos";
            this.groupBox1_Productos.Visible = false;
            // 
            // button2_ActualizarProductos
            // 
            this.button2_ActualizarProductos.Location = new System.Drawing.Point(434, 30);
            this.button2_ActualizarProductos.Name = "button2_ActualizarProductos";
            this.button2_ActualizarProductos.Size = new System.Drawing.Size(99, 31);
            this.button2_ActualizarProductos.TabIndex = 11;
            this.button2_ActualizarProductos.Text = "Actualizar";
            this.button2_ActualizarProductos.UseVisualStyleBackColor = true;
            this.button2_ActualizarProductos.Click += new System.EventHandler(this.button2_ActualizarProductos_Click_1);
            // 
            // button1_BorrarProductos
            // 
            this.button1_BorrarProductos.Location = new System.Drawing.Point(434, 72);
            this.button1_BorrarProductos.Name = "button1_BorrarProductos";
            this.button1_BorrarProductos.Size = new System.Drawing.Size(99, 29);
            this.button1_BorrarProductos.TabIndex = 10;
            this.button1_BorrarProductos.Text = "Borrar";
            this.button1_BorrarProductos.UseVisualStyleBackColor = true;
            this.button1_BorrarProductos.Click += new System.EventHandler(this.button1_BorrarProductos_Click);
            // 
            // comboBox2_Productos_Proveedor
            // 
            this.comboBox2_Productos_Proveedor.FormattingEnabled = true;
            this.comboBox2_Productos_Proveedor.Location = new System.Drawing.Point(130, 83);
            this.comboBox2_Productos_Proveedor.Name = "comboBox2_Productos_Proveedor";
            this.comboBox2_Productos_Proveedor.Size = new System.Drawing.Size(184, 21);
            this.comboBox2_Productos_Proveedor.TabIndex = 9;
            // 
            // comboBox1_Producto_Rubros
            // 
            this.comboBox1_Producto_Rubros.FormattingEnabled = true;
            this.comboBox1_Producto_Rubros.Location = new System.Drawing.Point(130, 55);
            this.comboBox1_Producto_Rubros.Name = "comboBox1_Producto_Rubros";
            this.comboBox1_Producto_Rubros.Size = new System.Drawing.Size(184, 21);
            this.comboBox1_Producto_Rubros.TabIndex = 8;
            // 
            // textBox3_PrecioProductos
            // 
            this.textBox3_PrecioProductos.Location = new System.Drawing.Point(298, 140);
            this.textBox3_PrecioProductos.Name = "textBox3_PrecioProductos";
            this.textBox3_PrecioProductos.Size = new System.Drawing.Size(100, 20);
            this.textBox3_PrecioProductos.TabIndex = 7;
            // 
            // textBox2_CostoProducto
            // 
            this.textBox2_CostoProducto.Location = new System.Drawing.Point(109, 136);
            this.textBox2_CostoProducto.Name = "textBox2_CostoProducto";
            this.textBox2_CostoProducto.Size = new System.Drawing.Size(100, 20);
            this.textBox2_CostoProducto.TabIndex = 6;
            // 
            // textBox1_ProductoNombre
            // 
            this.textBox1_ProductoNombre.Location = new System.Drawing.Point(130, 27);
            this.textBox1_ProductoNombre.Name = "textBox1_ProductoNombre";
            this.textBox1_ProductoNombre.Size = new System.Drawing.Size(184, 20);
            this.textBox1_ProductoNombre.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Costo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Rubro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Precio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Proveedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre";
            // 
            // groupBox1_Pedidos
            // 
            this.groupBox1_Pedidos.Controls.Add(this.textBox1_TotalPedido);
            this.groupBox1_Pedidos.Controls.Add(this.button1_AgregarPedido);
            this.groupBox1_Pedidos.Controls.Add(this.comboBox1_Pedidos);
            this.groupBox1_Pedidos.Controls.Add(this.button3_PedidosCerrar);
            this.groupBox1_Pedidos.Controls.Add(this.label13);
            this.groupBox1_Pedidos.Controls.Add(this.label12);
            this.groupBox1_Pedidos.Location = new System.Drawing.Point(1, 102);
            this.groupBox1_Pedidos.Name = "groupBox1_Pedidos";
            this.groupBox1_Pedidos.Size = new System.Drawing.Size(432, 120);
            this.groupBox1_Pedidos.TabIndex = 14;
            this.groupBox1_Pedidos.TabStop = false;
            this.groupBox1_Pedidos.Text = "Pedidos";
            this.groupBox1_Pedidos.Visible = false;
            this.groupBox1_Pedidos.Enter += new System.EventHandler(this.groupBox1_Pedidos_Enter);
            // 
            // textBox1_TotalPedido
            // 
            this.textBox1_TotalPedido.Location = new System.Drawing.Point(96, 90);
            this.textBox1_TotalPedido.Name = "textBox1_TotalPedido";
            this.textBox1_TotalPedido.Size = new System.Drawing.Size(100, 20);
            this.textBox1_TotalPedido.TabIndex = 5;
            // 
            // button1_AgregarPedido
            // 
            this.button1_AgregarPedido.Location = new System.Drawing.Point(244, 60);
            this.button1_AgregarPedido.Name = "button1_AgregarPedido";
            this.button1_AgregarPedido.Size = new System.Drawing.Size(123, 23);
            this.button1_AgregarPedido.TabIndex = 3;
            this.button1_AgregarPedido.Text = "Agregar pedido";
            this.button1_AgregarPedido.UseVisualStyleBackColor = true;
            this.button1_AgregarPedido.Click += new System.EventHandler(this.button1_AgregarPedido_Click);
            // 
            // comboBox1_Pedidos
            // 
            this.comboBox1_Pedidos.FormattingEnabled = true;
            this.comboBox1_Pedidos.Location = new System.Drawing.Point(87, 26);
            this.comboBox1_Pedidos.Name = "comboBox1_Pedidos";
            this.comboBox1_Pedidos.Size = new System.Drawing.Size(247, 21);
            this.comboBox1_Pedidos.TabIndex = 2;
            // 
            // button3_PedidosCerrar
            // 
            this.button3_PedidosCerrar.Location = new System.Drawing.Point(244, 90);
            this.button3_PedidosCerrar.Name = "button3_PedidosCerrar";
            this.button3_PedidosCerrar.Size = new System.Drawing.Size(123, 23);
            this.button3_PedidosCerrar.TabIndex = 4;
            this.button3_PedidosCerrar.Text = "Cerrar Pedidos";
            this.button3_PedidosCerrar.UseVisualStyleBackColor = true;
            this.button3_PedidosCerrar.Visible = false;
            this.button3_PedidosCerrar.Click += new System.EventHandler(this.button3_PedidosCerrar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "$";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Usuario";
            // 
            // groupBox1_ItemPedido
            // 
            this.groupBox1_ItemPedido.Controls.Add(this.textBox3_ItemDTO);
            this.groupBox1_ItemPedido.Controls.Add(this.textBox2_ItemPrecio);
            this.groupBox1_ItemPedido.Controls.Add(this.textBox1_ItemCantidad);
            this.groupBox1_ItemPedido.Controls.Add(this.button2_AgrgarItem);
            this.groupBox1_ItemPedido.Controls.Add(this.label17);
            this.groupBox1_ItemPedido.Controls.Add(this.comboBox2_PedidoItem);
            this.groupBox1_ItemPedido.Controls.Add(this.label16);
            this.groupBox1_ItemPedido.Controls.Add(this.label15);
            this.groupBox1_ItemPedido.Controls.Add(this.label14);
            this.groupBox1_ItemPedido.Location = new System.Drawing.Point(551, 104);
            this.groupBox1_ItemPedido.Name = "groupBox1_ItemPedido";
            this.groupBox1_ItemPedido.Size = new System.Drawing.Size(466, 119);
            this.groupBox1_ItemPedido.TabIndex = 15;
            this.groupBox1_ItemPedido.TabStop = false;
            this.groupBox1_ItemPedido.Text = "Item Pedido N°";
            this.groupBox1_ItemPedido.UseCompatibleTextRendering = true;
            this.groupBox1_ItemPedido.Visible = false;
            // 
            // textBox3_ItemDTO
            // 
            this.textBox3_ItemDTO.Location = new System.Drawing.Point(79, 82);
            this.textBox3_ItemDTO.Name = "textBox3_ItemDTO";
            this.textBox3_ItemDTO.Size = new System.Drawing.Size(87, 20);
            this.textBox3_ItemDTO.TabIndex = 9;
            // 
            // textBox2_ItemPrecio
            // 
            this.textBox2_ItemPrecio.Location = new System.Drawing.Point(222, 82);
            this.textBox2_ItemPrecio.Name = "textBox2_ItemPrecio";
            this.textBox2_ItemPrecio.Size = new System.Drawing.Size(87, 20);
            this.textBox2_ItemPrecio.TabIndex = 8;
            // 
            // textBox1_ItemCantidad
            // 
            this.textBox1_ItemCantidad.Location = new System.Drawing.Point(81, 20);
            this.textBox1_ItemCantidad.Name = "textBox1_ItemCantidad";
            this.textBox1_ItemCantidad.Size = new System.Drawing.Size(87, 20);
            this.textBox1_ItemCantidad.TabIndex = 7;
            this.textBox1_ItemCantidad.Text = "1";
            // 
            // button2_AgrgarItem
            // 
            this.button2_AgrgarItem.Location = new System.Drawing.Point(337, 82);
            this.button2_AgrgarItem.Name = "button2_AgrgarItem";
            this.button2_AgrgarItem.Size = new System.Drawing.Size(102, 23);
            this.button2_AgrgarItem.TabIndex = 6;
            this.button2_AgrgarItem.Text = "Agregar Item";
            this.button2_AgrgarItem.UseVisualStyleBackColor = true;
            this.button2_AgrgarItem.Click += new System.EventHandler(this.button2_AgrgarItem_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "DTO";
            // 
            // comboBox2_PedidoItem
            // 
            this.comboBox2_PedidoItem.FormattingEnabled = true;
            this.comboBox2_PedidoItem.Location = new System.Drawing.Point(255, 19);
            this.comboBox2_PedidoItem.Name = "comboBox2_PedidoItem";
            this.comboBox2_PedidoItem.Size = new System.Drawing.Size(184, 21);
            this.comboBox2_PedidoItem.TabIndex = 4;
            this.comboBox2_PedidoItem.SelectedIndexChanged += new System.EventHandler(this.comboBox2_PedidoItem_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(180, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "precio";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "cantidad";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(189, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Producto";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(648, 257);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(369, 153);
            this.dataGridView2.TabIndex = 16;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // button1_SALIR
            // 
            this.button1_SALIR.Location = new System.Drawing.Point(920, 11);
            this.button1_SALIR.Name = "button1_SALIR";
            this.button1_SALIR.Size = new System.Drawing.Size(97, 37);
            this.button1_SALIR.TabIndex = 17;
            this.button1_SALIR.Text = "SALIR";
            this.button1_SALIR.UseVisualStyleBackColor = true;
            this.button1_SALIR.Click += new System.EventHandler(this.button1_SALIR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 514);
            this.Controls.Add(this.button1_SALIR);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1_ItemPedido);
            this.Controls.Add(this.groupBox1_Pedidos);
            this.Controls.Add(this.groupBox1_Productos);
            this.Controls.Add(this.groupBox1_Proveedores);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.textBox1_idInvisible);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1_usuarios);
            this.Controls.Add(this.groupBox1_Rubros);
            this.Controls.Add(this.button5_PEDIDOS);
            this.Controls.Add(this.button4_PRODUCTOS);
            this.Controls.Add(this.button3_PROVEEDORES);
            this.Controls.Add(this.button2_RUBROS);
            this.Controls.Add(this.button1_USUARIOS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1_usuarios.ResumeLayout(false);
            this.groupBox1_usuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1_Rubros.ResumeLayout(false);
            this.groupBox1_Rubros.PerformLayout();
            this.groupBox1_Proveedores.ResumeLayout(false);
            this.groupBox1_Proveedores.PerformLayout();
            this.groupBox1_Productos.ResumeLayout(false);
            this.groupBox1_Productos.PerformLayout();
            this.groupBox1_Pedidos.ResumeLayout(false);
            this.groupBox1_Pedidos.PerformLayout();
            this.groupBox1_ItemPedido.ResumeLayout(false);
            this.groupBox1_ItemPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_USUARIOS;
        private System.Windows.Forms.Button button2_RUBROS;
        private System.Windows.Forms.Button button3_PROVEEDORES;
        private System.Windows.Forms.Button button4_PRODUCTOS;
        private System.Windows.Forms.Button button5_PEDIDOS;
        private System.Windows.Forms.GroupBox groupBox1_usuarios;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4_UsuariosTelefono;
        private System.Windows.Forms.TextBox textBox3_UsuariosEmail;
        private System.Windows.Forms.TextBox textBox2_UsuariosDireccion;
        private System.Windows.Forms.TextBox textBox1_UsuarioNombres;
        private System.Windows.Forms.Button button2_Borrar_Usuarios;
        private System.Windows.Forms.Button button1_Actualizar_Usuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1_Rubros;
        private System.Windows.Forms.Button button2_RubrosBorrar;
        private System.Windows.Forms.Button button1_RubrosActualizar;
        private System.Windows.Forms.TextBox textBox1_RubrosNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1_idInvisible;
        private System.Windows.Forms.Label mensaje;
        private System.Windows.Forms.GroupBox groupBox1_Proveedores;
        private System.Windows.Forms.Button button2_ProveedoresBorrar;
        private System.Windows.Forms.Button button1_ProveedoresActualizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1_Proveedores;
        private System.Windows.Forms.GroupBox groupBox1_Productos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2_Productos_Proveedor;
        private System.Windows.Forms.ComboBox comboBox1_Producto_Rubros;
        private System.Windows.Forms.TextBox textBox3_PrecioProductos;
        private System.Windows.Forms.TextBox textBox2_CostoProducto;
        private System.Windows.Forms.TextBox textBox1_ProductoNombre;
        private System.Windows.Forms.Button button2_ActualizarProductos;
        private System.Windows.Forms.Button button1_BorrarProductos;
        private System.Windows.Forms.GroupBox groupBox1_Pedidos;
        private System.Windows.Forms.GroupBox groupBox1_ItemPedido;
        private System.Windows.Forms.Button button3_PedidosCerrar;
        private System.Windows.Forms.Button button1_AgregarPedido;
        private System.Windows.Forms.ComboBox comboBox1_Pedidos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2_AgrgarItem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox2_PedidoItem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox1_TotalPedido;
        private System.Windows.Forms.TextBox textBox3_ItemDTO;
        private System.Windows.Forms.TextBox textBox2_ItemPrecio;
        private System.Windows.Forms.TextBox textBox1_ItemCantidad;
        private System.Windows.Forms.Button button1_SALIR;
    }
}

