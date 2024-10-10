using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S063enRaya
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char Turno = 'O'; //variable que controla el turno de cada jugador
        int movimiento = 0; //variable que controla el numero de movimientos en la partida
        List<Button> buttons; //Lista que almacena todos los botones para que el NPC elija la posicion
        Random rand = new Random(); //Variable random que eligira un boton de la lista
        int x = 0, o = 0, npc = 0; //variable que controla la puntuacion de la partida
        bool jugandoNPC = false; //variable que controla si esta jugando el npc

        public MainWindow()
        {
            InitializeComponent();

            cargarBotons(); //cargo la lista con todos los botones
        }

        private void cargarBotons() //funcion que carga todos los botones en una lista
        {
            buttons = new List<Button>() { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }


        private void PlayerClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button; //creo una variable button donde almaceno el boton presionado 


            if (Turno == 'O') //si el tunor es del jugador princiapal 0
            {
                button.Content = "O"; //asigno el valor 0 al contenido del boton
                buttons.Remove(button); //elimino el boton selecionado de la lista
                button.IsEnabled = false; //desactivo el boton
                SolidColorBrush nuevoColor = new SolidColorBrush(Colors.Blue); //creo un color azul para la letra del boton
                button.Foreground = nuevoColor; //asigno el color de letra al boton
                Turno = 'X'; //cambio el turno del jugador
                movimiento++; //sumo uno al valor de los movimientos
                Check(); //miro si hay algun ganador


            }
            else if (Turno == 'X' && !jugandoNPC) //si el turno es del segundo jugador y no esta jugando el npc
            {

                button.Content = "X"; //asigno el valor x al contenido del boton
                button.IsEnabled = false; //desactivo el boton 
                SolidColorBrush nuevoColor = new SolidColorBrush(Colors.Red); //creo un color para la letra del boton
                button.Foreground = nuevoColor; //asigno el color creado al boton
                Turno = 'O'; //cambio el turno del jugador
                movimiento++; //sumo uno al valor de los movimientos
                Check(); //miro si hay algun ganador
                TurnoNPC.IsEnabled = false;         //

            }

        }

        private void Check() //funcion que verifica todas las posibilidades de victoria del jugador 2 o NPC
        {
            if (btn1.Content == btn2.Content && btn2.Content == btn3.Content && btn2.Content == "X"
               || btn4.Content == btn5.Content && btn5.Content == btn6.Content && btn6.Content == "X"
               || btn7.Content == btn8.Content && btn8.Content == btn9.Content && btn9.Content == "X"
               || btn1.Content == btn4.Content && btn4.Content == btn7.Content && btn7.Content == "X"
               || btn2.Content == btn5.Content && btn5.Content == btn8.Content && btn8.Content == "X"
               || btn3.Content == btn6.Content && btn6.Content == btn9.Content && btn9.Content == "X"
               || btn1.Content == btn5.Content && btn5.Content == btn9.Content && btn9.Content == "X"
               || btn3.Content == btn5.Content && btn5.Content == btn7.Content && btn7.Content == "X")
            {

                if (jugandoNPC) //si esta jugando el NPC
                {
                    npc++; //sumo uno al valor de las victorias del npc
                    PLAYERNPC.Content = "NPC (X): " + npc; //muestro el mensaje de victoria del npc
                    MessageBox.Show("Ganado de la partida el NPC X ", "Ganador", MessageBoxButton.OK, MessageBoxImage.Information); //muestro ventana informando de la victoria NPC

                }
                else //Si no esta jugando el npc esta jugando el jugador 2
                {
                    x++; //sumo uno al valor de la victoria del jugador 2
                    Player1.Content = "Jugador (X): " + x; //muestro el mensaje de la victoria del jugador 2
                    MessageBox.Show("Ganador de la partida X ","Ganador", MessageBoxButton.OK, MessageBoxImage.Information); //muestro ventana informando de la vistoria del jugador 2

                }

            }
            //funcion que verifica todas las posibilidades de victoria del jugador principal
            else if (btn1.Content == btn2.Content && btn2.Content == btn3.Content && btn2.Content == "O"
                   || btn4.Content == btn5.Content && btn5.Content == btn6.Content && btn6.Content == "O"
                   || btn7.Content == btn8.Content && btn8.Content == btn9.Content && btn9.Content == "O"
                   || btn1.Content == btn4.Content && btn4.Content == btn7.Content && btn7.Content == "O"
                   || btn2.Content == btn5.Content && btn5.Content == btn8.Content && btn8.Content == "O"
                   || btn3.Content == btn6.Content && btn6.Content == btn9.Content && btn9.Content == "O"
                   || btn1.Content == btn5.Content && btn5.Content == btn9.Content && btn9.Content == "O"
                   || btn3.Content == btn5.Content && btn5.Content == btn7.Content && btn7.Content == "O")
            {
                o++; //sumo uno al valor de la victorias del jugador principal
                Player2.Content = "Jugador (O): " + o; //muestro mensaje informando de la victoria
                MessageBox.Show("Ganador de la partida O","Ganador",MessageBoxButton.OK,MessageBoxImage.Information); //muestro ventana informando de la vistoria del jugador principal

            }
            else if (movimiento == 9) //si no hay victoria i los movimientos son igual a 9
            {
                MessageBox.Show("EMPATE","EMPATE",MessageBoxButton.OK,MessageBoxImage.Exclamation); //muestro mensaje que es un empate
//);

            }
        }


        private void restartGame(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = true; btn1.Content = "";
            btn2.IsEnabled = true; btn2.Content = "";
            btn3.IsEnabled = true; btn3.Content = "";
            btn4.IsEnabled = true; btn4.Content = "";
            btn5.IsEnabled = true; btn5.Content = "";
            btn6.IsEnabled = true; btn6.Content = "";
            btn7.IsEnabled = true; btn7.Content = "";
            btn8.IsEnabled = true; btn8.Content = "";
            btn9.IsEnabled = true; btn9.Content = "";
            TurnoNPC.IsEnabled = true;
            movimiento = 0;
            Turno = 'O';
            cargarBotons();
            jugandoNPC = false;

        }

        private void NPC(object sender, RoutedEventArgs e)
        {
            jugandoNPC = true; //cambio el valor de jugando npc a true
            int index = rand.Next(buttons.Count); //variable que almacena el boton selecionado de la lista

            Button button = sender as Button; //creo una variable que almacena el valor del boton
            button = buttons[index]; //asigno el valor selecionado por el npc en el boton creado anteriormente

            if (buttons.Count > 0 && Turno == 'X' && jugandoNPC) //si en la lista hay botones disponibles i es turno del jugador NPC i esta jugando el npc
            {
                button.Content = "X"; //asigno el valor x al contenido del boton selecionado
                button.IsEnabled = false; //desactivo el boton
                buttons.Remove(button); //elimino el boton selecionado de la lista
                SolidColorBrush nuevoColor = new SolidColorBrush(Colors.Coral); //creo un color para la letra del boton
                button.Foreground = nuevoColor; //asigno un color a la letra del boton
                Turno = 'O'; //cambio el turno del jugador
                movimiento++; //sumo un movimiento a la partida
                Check(); //verifico si hay victoria
            }

        }
    }
}
