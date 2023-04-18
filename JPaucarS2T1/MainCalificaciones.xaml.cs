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
    public partial class MainCalificaciones : ContentPage
    {
        public MainCalificaciones()
        {
            InitializeComponent();
        }

        //Muestra dependiendo de la bandera un tipo de mensaje de error
        private async Task AlertaErrorAsync(bool caracteres = false)
        {
            if (caracteres)
                await DisplayAlert("Error de validación", "No se permite notas mayores a 10 ni menores a 1, por favor intente nuevamente", "Aceptar");
            else
                await DisplayAlert("Error de validación", "Debe ingresar valores en todas las cajas de texto permitidas, por favor intente nuevamente", "Aceptar");
        }

        private async void TxtPrimerParcial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPrimerParcial.Text))
            {
                if (!double.TryParse(TxtPrimerParcial.Text, out double numero))
                    TxtPrimerParcial.Text = string.Empty;
                else
                {
                    if (numero < 1 || numero > 10)
                    {
                        await AlertaErrorAsync(true);
                        TxtPrimerParcial.Text = string.Empty;
                    }
                }
            }
        }

        private async void TxtPrimerExamen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPrimerExamen.Text))
            {
                if (!double.TryParse(TxtPrimerExamen.Text, out double numero))
                    TxtPrimerExamen.Text = string.Empty;
                else
                {
                    if (numero < 1 || numero > 10)
                    {
                        await AlertaErrorAsync(true);
                        TxtPrimerExamen.Text = string.Empty;
                    }
                }
            }
        }

        private async void TxtSegundoParcial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSegundoParcial.Text))
            {
                if (!double.TryParse(TxtSegundoParcial.Text, out double numero))
                    TxtSegundoParcial.Text = string.Empty;
                else
                {
                    if (numero < 1 || numero > 10)
                    {
                        await AlertaErrorAsync(true);
                        TxtSegundoParcial.Text = string.Empty;
                    }
                }
            }
        }

        private async void TxtSegundoExamen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSegundoExamen.Text))
            {
                if (!double.TryParse(TxtSegundoExamen.Text, out double numero))
                    TxtSegundoExamen.Text = string.Empty;
                else
                {
                    if (numero < 1 || numero > 10)
                    {
                        await AlertaErrorAsync(true);
                        TxtSegundoExamen.Text = string.Empty;
                    }
                }
            }
        }

        private async void BtnCalcularTotal_Clicked(object sender, EventArgs e)
        {
            //Validación de cajas de texto vacías
            if (!string.IsNullOrEmpty(TxtPrimerParcial.Text) && !string.IsNullOrEmpty(TxtPrimerExamen.Text) && !string.IsNullOrEmpty(TxtSegundoParcial.Text) && !string.IsNullOrEmpty(TxtSegundoExamen.Text))
            {
                //Obtención de valores de interfaz
                double primerParcial = Convert.ToDouble(TxtPrimerParcial.Text);
                double primerExamen = Convert.ToDouble(TxtPrimerExamen.Text);
                double segundoParcial = Convert.ToDouble(TxtSegundoParcial.Text);
                double segundoExamen = Convert.ToDouble(TxtSegundoExamen.Text);

                //Cálculos
                double promedioPrimerParcial = (primerParcial * 0.3) + (primerExamen * 0.2);
                double promedioSegundoParcial = (segundoParcial * 0.3) + (segundoExamen * 0.2);
                double promedioFinal = promedioPrimerParcial + promedioSegundoParcial;

                TxtTotalPrimerParcial.Text = Convert.ToString(promedioPrimerParcial);
                TxtTotalSegundoParcial.Text = Convert.ToString(promedioSegundoParcial);

                TxtPromedioFinal.Text = Convert.ToString(promedioFinal);

                if (promedioFinal >= 7)
                {
                    LblEstado.Text = "APROBADO";
                    LblEstado.TextColor = Color.Green;
                }
                else
                {
                    LblEstado.Text = "REPROBADO";
                    LblEstado.TextColor = Color.Red;
                }
            }
            else
                await AlertaErrorAsync();
        }

        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            TxtPrimerParcial.Text = string.Empty;
            TxtPrimerExamen.Text = string.Empty;
            TxtTotalPrimerParcial.Text = string.Empty; ;

            TxtSegundoParcial.Text = string.Empty;
            TxtSegundoExamen.Text = string.Empty;
            TxtTotalSegundoParcial.Text = string.Empty;

            TxtPromedioFinal.Text = string.Empty;
            LblEstado.Text = string.Empty;
            LblEstado.TextColor = Color.White;
        }
    }
}