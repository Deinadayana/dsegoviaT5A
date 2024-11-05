using dsegoviaS5A.Models;

namespace dsegoviaS5A.Views;

public partial class Principal : ContentPage
{
    public Principal()
    {
        InitializeComponent();
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "OK";
        List<Persona> personas = App.PersonRepo.GetAllPeople();
        listaPersona.ItemsSource = personas;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.AddNewPerson(txtNombre.Text);
        lblStatus.Text = App.PersonRepo.StatusMessage;
        txtNombre.Text = ""; // Limpiar el campo de entrada
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.PersonRepo.UpdatePerson(id, txtNombre.Text);
            lblStatus.Text = App.PersonRepo.StatusMessage;
            txtNombre.Text = ""; // Limpiar el campo de entrada
            txtId.Text = ""; // Limpiar el campo de ID
        }
        else
        {
            lblStatus.Text = "Por favor ingrese un ID válido.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.PersonRepo.DeletePerson(id);
            lblStatus.Text = App.PersonRepo.StatusMessage;
            txtId.Text = ""; // Limpiar el campo de ID
        }
        else
        {
            lblStatus.Text = "Por favor ingrese un ID válido.";
        }
    }
}

