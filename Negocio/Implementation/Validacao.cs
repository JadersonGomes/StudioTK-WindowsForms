using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Implementation
{
    public class Validacao : IValidacao
    {
        public bool ValidarAgendamento(Control nomePainel)
        {
            bool campoVazio = false;

            foreach (Control verifica in nomePainel.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)) || verifica.GetType().Equals(typeof(DateTimePicker)) || 
                    verifica.GetType().Equals(typeof(ComboBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        campoVazio = true;
                        break;
                    }
                }

            }

            return campoVazio;
        }

        public bool ValidarColaboradorOuFornecedor(GroupBox groupBox1, GroupBox groupBox2)
        {
            bool campoVazio = false;

            foreach (Control verifica in groupBox1.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)) || verifica.GetType().Equals(typeof(ComboBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        campoVazio = true;
                        break;
                    }
                    
                }

            }

            foreach (Control verifica in groupBox2.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)) || verifica.GetType().Equals(typeof(ComboBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        campoVazio = true;
                        break;
                    }
                }

            }

            return campoVazio;
        }

        public bool ValidarPadrao(Control nomePainel)
        {
            bool campoVazio = false;

            foreach (Control verifica in nomePainel.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)) || verifica.GetType().Equals(typeof(ComboBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        campoVazio = true;
                        break;
                    }
                }

            }

            return campoVazio;
        }


        public bool ValidarUsuario(Control nomePainel)
        {
            bool campoVazio = false;

            foreach (Control verifica in nomePainel.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)))
                {
                    if (verifica.Text == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        campoVazio = true;
                        break;
                    }
                }

            }

            return campoVazio;
        }


        public bool ValidarCliente(Control nomePainel)
        {
            bool campoVazio = false;

            foreach (Control verifica in nomePainel.Controls)
            {
                if (verifica.GetType().Equals(typeof(TextBox)) || verifica.GetType().Equals(typeof(MaskedTextBox)))
                {
                    var mascara = (MaskedTextBox)verifica;
                    var semMascara = RemoverMascara(mascara);

                    if (verifica.Text == string.Empty || semMascara == string.Empty)
                    {
                        //verifica.BackColor = Color.Yellow;
                        //MessageBox.Show("Por gentileza, preencha todos os campos.");
                        campoVazio = true;
                        break;
                    }
                }

            }

            return campoVazio;
        }

        public string RemoverMascara(MaskedTextBox mascara)
        {
            mascara.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var valorSemMascara = mascara.Text;
            mascara.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            return valorSemMascara;
        }


        public bool ValidarEmail(string email)
        {
            bool deuCerto = false;

            if (email.IndexOf('@') == -1 && email.IndexOf('.') == -1 && !(email.ToString().Equals("")))
            {
                MessageBox.Show("E-mail inválido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            } else
            {
                deuCerto = true;
            }

            return deuCerto;
        }
    }
}
