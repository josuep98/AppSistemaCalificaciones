using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JPaucarS2T1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private const string User = "estudiante2023";
        private const string Pass = "uisrael2023";

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (TxtUsuario.Text.Equals(User) && TxtPass.Text.Equals(Pass))
                Navigation.PushAsync(new MainCalificaciones(User));
            else
                DisplayAlert("Error de ingreso", "El usuario y/o contraseña son incorrectos, por favor intente de nuevo", "Aceptar");
            Limpiar();
        }

        private void Limpiar()
        {
            TxtUsuario.Text = string.Empty;
            TxtPass.Text = string.Empty;
        }

    }
}