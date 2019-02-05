using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Interfaces
{
    public interface IValidacao
    {
        bool ValidarAgendamento(Control nomePainel);
        bool ValidarColaboradorOuFornecedor(GroupBox groupBox1, GroupBox groupBox2);
        bool ValidarPadrao(Control nomePainel);
        bool ValidarUsuario(Control nomePainel);
        bool ValidarCliente(Control nomePainel);
        string RemoverMascara(MaskedTextBox mascara);
        bool ValidarEmail(string email);

    }
}
