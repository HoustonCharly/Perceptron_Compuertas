using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prac4Perceptron
{
    public partial class Form1 : Form
    {
          operaciones dosentradas = new operaciones(2,1d); //Se usa una extencion de esta clase para operar AND OR XOR y EJEMPLO
          operaciones tresentradas = new operaciones(3,3d); //Se usa otro objeto para Mayoria Simple con 3 variables
          operaciones cuatroentradas = new operaciones(4,2d); //Se usa otro objeto de 4 entradas para Paridad

        bool VF = false;//Inicia la variable VErdad o Falso de tipo boolenao

        public Form1()
        {
            InitializeComponent();
        }
        private void Bt1_Click(object sender, EventArgs e)
        {
            //Limpia la tabla para cambiar de ejercicio
            Gridtabla.Columns.Clear(); 
            lBsalida.Items.Clear();

            if (Problema.Text=="AND")
            {
                Procesoand();
                Gridtabla.Columns.Add("x1","X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("0", "0","0", dosentradas.Operaneurona(new double[2] {0, 0}));
                Gridtabla.Rows.Add("0", "1","0", dosentradas.Operaneurona(new double[2] {0, 1}));
                Gridtabla.Rows.Add("1", "0","0", dosentradas.Operaneurona(new double[2] {1, 0}));
                Gridtabla.Rows.Add("1", "1","1", dosentradas.Operaneurona(new double[2] {1, 1}));

            }
            if (Problema.Text=="OR")
            {
                Procesor();
                Gridtabla.Columns.Add("x1", "X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("0", "0", "0", dosentradas.Operaneurona(new double[2] {0, 0}));
                Gridtabla.Rows.Add("0", "1", "1", dosentradas.Operaneurona(new double[2] {0, 1}));
                Gridtabla.Rows.Add("1", "0", "1", dosentradas.Operaneurona(new double[2] {1, 0}));
                Gridtabla.Rows.Add("1", "1", "1", dosentradas.Operaneurona(new double[2] {1, 1}));
            }
            if (Problema.Text=="XOR")
            {
                Procesoxor();
                Gridtabla.Columns.Add("x1", "X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("0", "0", "0", dosentradas.Operaneurona(new double[2] {0, 0}));
                Gridtabla.Rows.Add("0", "1", "1", dosentradas.Operaneurona(new double[2] {0, 1}));
                Gridtabla.Rows.Add("1", "0", "1", dosentradas.Operaneurona(new double[2] {1, 0}));
                Gridtabla.Rows.Add("1", "1", "0", dosentradas.Operaneurona(new double[2] {1, 1}));
            }
            if (Problema.Text=="EJERCICIO")
            {
                Procesoejercicio();
                Gridtabla.Columns.Add("x1", "X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("2", "0", "1", dosentradas.Operaneurona(new double[2] {2, 0}));
                Gridtabla.Rows.Add("0", "0", "0", dosentradas.Operaneurona(new double[2] {0, 0}));
                Gridtabla.Rows.Add("2", "2", "1", dosentradas.Operaneurona(new double[2] {2, 2}));
                Gridtabla.Rows.Add("0", "1", "0", dosentradas.Operaneurona(new double[2] {0, 1}));
                Gridtabla.Rows.Add("1", "1", "1", dosentradas.Operaneurona(new double[2] {1, 1}));
                Gridtabla.Rows.Add("1", "2", "0", dosentradas.Operaneurona(new double[2] {1, 2}));

            }
            if(Problema.Text=="MAYORIA SIMPLE")
            {
                ProcesoMayoria();
                Gridtabla.Columns.Add("x1", "X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("x3", "X3");

                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("0", "0", "0","0", tresentradas.Operaneurona(new double[3] {0, 0, 0}));
                Gridtabla.Rows.Add("0", "0", "1","0", tresentradas.Operaneurona(new double[3] {0, 0, 1}));
                Gridtabla.Rows.Add("0", "1", "0","0", tresentradas.Operaneurona(new double[3] {0, 1, 0}));
                Gridtabla.Rows.Add("0", "1", "1","1", tresentradas.Operaneurona(new double[3] {0, 1, 1}));
                
                Gridtabla.Rows.Add("1", "0", "0","0", tresentradas.Operaneurona(new double[3] { 1, 0, 0}));
                Gridtabla.Rows.Add("1", "0", "1","1", tresentradas.Operaneurona(new double[3] { 1, 2, 1}));
                Gridtabla.Rows.Add("1", "1", "0","1", tresentradas.Operaneurona(new double[3] { 1, 1, 0}));
                Gridtabla.Rows.Add("1", "1", "1","1", tresentradas.Operaneurona(new double[3] { 1, 2, 1}));

            }
            if (Problema.Text=="PARIDAD")
            {
                ProcesoParidad();
                Gridtabla.Columns.Add("x1", "X1");
                Gridtabla.Columns.Add("x2", "X2");
                Gridtabla.Columns.Add("x3", "X3");
                Gridtabla.Columns.Add("x4", "X4");

                Gridtabla.Columns.Add("ye", "Y esperada");
                Gridtabla.Columns.Add("yo", "Y obtenida");

                Gridtabla.Rows.Add("0", "0", "0", "0", "0", cuatroentradas.Operaneurona(new double[4] {0, 0, 0, 0 }));
                Gridtabla.Rows.Add("0", "0", "0", "1", "0", cuatroentradas.Operaneurona(new double[4] {0, 0, 0, 1 }));
                Gridtabla.Rows.Add("0", "0", "1", "0", "0", cuatroentradas.Operaneurona(new double[4] {0, 0, 1, 0 }));
                Gridtabla.Rows.Add("0", "0", "1", "1", "1", cuatroentradas.Operaneurona(new double[4] {0, 0, 1, 1 }));
                Gridtabla.Rows.Add("0", "1", "0", "0", "0", cuatroentradas.Operaneurona(new double[4] {0, 1, 0, 0 }));
                Gridtabla.Rows.Add("0", "1", "0", "1", "1", cuatroentradas.Operaneurona(new double[4] {0, 1, 0, 1 }));
                Gridtabla.Rows.Add("0", "1", "1", "0", "1", cuatroentradas.Operaneurona(new double[4] {0, 1, 1, 0 }));
                Gridtabla.Rows.Add("0", "1", "1", "1", "0", cuatroentradas.Operaneurona(new double[4] {0, 1, 1, 1 }));

                Gridtabla.Rows.Add("1", "0", "0", "0", "0", cuatroentradas.Operaneurona(new double[4] {1, 0, 0, 0 }));
                Gridtabla.Rows.Add("1", "0", "0", "1", "1", cuatroentradas.Operaneurona(new double[4] {1, 0, 0, 1 }));
                Gridtabla.Rows.Add("1", "0", "1", "0", "1", cuatroentradas.Operaneurona(new double[4] {1, 0, 1, 0 }));
                Gridtabla.Rows.Add("1", "0", "1", "1", "0", cuatroentradas.Operaneurona(new double[4] {1, 0, 1, 1 }));
                Gridtabla.Rows.Add("1", "1", "0", "0", "1", cuatroentradas.Operaneurona(new double[4] {1, 1, 0, 0 }));
                Gridtabla.Rows.Add("1", "1", "0", "1", "0", cuatroentradas.Operaneurona(new double[4] {1, 1, 0, 1 }));
                Gridtabla.Rows.Add("1", "1", "1", "0", "0", cuatroentradas.Operaneurona(new double[4] {1, 1, 1, 0 }));
                Gridtabla.Rows.Add("1", "1", "1", "1", "1", cuatroentradas.Operaneurona(new double[4] {1, 1, 1, 1 }));

            }
        }

        #region PROCESOAND
        public void Procesoand()
        {
            int counter = 0;
            while (!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);
                
                lBsalida.Items.Add("W1: "+dosentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+dosentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("Umbral θ: "+dosentradas.Umbralinicial);

                if (dosentradas.Operaneurona(new double[2] {0, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {0, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {0, 1}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {0, 1}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {1, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {1, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {1, 1}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {1, 1}, 1);
                    VF = false;
                }

                lBsalida.Items.Add("0    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] {0, 0}), 3));
                lBsalida.Items.Add("0    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] {0, 1}), 3));
                lBsalida.Items.Add("1    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] {1, 0}), 3));
                lBsalida.Items.Add("1    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] {1, 1}), 3));
                lBsalida.Items.Add(" \n ");
            }

        }
        #endregion

        #region PROCESOR
        public void Procesor()
        {
            int counter = 0;
            while (!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);

                lBsalida.Items.Add("W1: "+dosentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+dosentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("Umbral θ: "+dosentradas.Umbralinicial);


                if (dosentradas.Operaneurona(new double[2] {0, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {0, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {0, 1}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {0, 1}, 1);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {1, 0}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {1, 0}, 1);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] {1, 1}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {1, 1}, 1);
                    VF = false;
                }

                lBsalida.Items.Add("0    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 0}), 3));
                lBsalida.Items.Add("0    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 1}), 3));
                lBsalida.Items.Add("1    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 0}), 3));
                lBsalida.Items.Add("1    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 1}), 3));
                lBsalida.Items.Add(" \n ");
            }

        }
        #endregion

        #region PROCESOXOR
        public void Procesoxor()
        {
            int counter = 0;
            while(!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);

                lBsalida.Items.Add("W1: "+dosentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+dosentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("Umbral θ: "+dosentradas.Umbralinicial);

                if (dosentradas.Operaneurona(new double[2] { 0, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 0, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 0, 1}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 0, 1}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 1, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 1, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 1, 1}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 1, 1}, 1);
                    VF = false;
                }

                lBsalida.Items.Add("0    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 0}), 7));
                lBsalida.Items.Add("0    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 1}), 7));
                lBsalida.Items.Add("1    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 0}), 7));
                lBsalida.Items.Add("1    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 1}), 7));

                lBsalida.Items.Add(" \n ");
                if (++counter == 50)
                {
                    break;
                }
            }
            MessageBox.Show("No encontro solución");
        }
        #endregion

        #region EJERCICIO
        public void Procesoejercicio()
        {
            int counter = 0;
            while(!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);

                lBsalida.Items.Add("W1: "+dosentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+dosentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("Umbral θ: "+dosentradas.Umbralinicial);

                if (dosentradas.Operaneurona(new double[2] { 2, 0}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 2, 0}, 1);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 0, 0}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 0, 0}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 2, 2}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 2, 2}, 1);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 0, 1}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 0, 1}, 0);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 1, 1}) !=1)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] {1, 1}, 1);
                    VF = false;
                }
                if (dosentradas.Operaneurona(new double[2] { 1, 2}) !=0)
                {
                    dosentradas.OpNuevoAprendizaje(new double[2] { 1, 2}, 0);
                    VF = false;
                }

                lBsalida.Items.Add(" 2    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 2, 0 }), 7));
                lBsalida.Items.Add(" 0    0 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 0 }), 7));
                lBsalida.Items.Add(" 2    2 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 2, 2 }), 7));
                lBsalida.Items.Add(" 0    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 0, 1 }), 7));
                lBsalida.Items.Add(" 1    1 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 1 }), 7));
                lBsalida.Items.Add(" 1    2 : " + Math.Round(dosentradas.Operaneurona(new double[2] { 1, 2 }), 7));
                lBsalida.Items.Add(" \n ");

            }
        }
        #endregion

        #region MAYORIA SIMPLE
        public void ProcesoMayoria()
        {
            int counter = 0;
            while (!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);

                lBsalida.Items.Add("W1: "+tresentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+tresentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("W3: "+tresentradas.Pesosiniciales[2]);

                lBsalida.Items.Add("Umbral θ: "+tresentradas.Umbralinicial);

                if (tresentradas.Operaneurona(new double[3] { 0, 0, 0}) !=0)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] { 0, 0, 0}, 0);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 0, 0, 1}) !=0)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] { 0, 0, 1}, 0);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 0, 1, 0}) !=0)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] { 0, 1, 0}, 0);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 0, 1, 1}) !=1)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] { 0, 1, 1}, 1);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 1, 0, 0}) !=0)
                {
                   tresentradas.OpNuevoAprendizaje(new double[3] {1, 0, 0}, 0);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 1, 0, 1}) !=1)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] {1, 0, 1}, 1);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 1, 1, 0}) !=1)
                {
                    tresentradas.OpNuevoAprendizaje(new double[3] { 1, 1, 0}, 1);
                    VF = false;
                }
                if (tresentradas.Operaneurona(new double[3] { 1, 1, 1}) !=1)
                {
                   tresentradas.OpNuevoAprendizaje(new double[3] { 1, 1, 1}, 1);
                    VF = false;
                }

                lBsalida.Items.Add(" 0  0  0 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 0, 0, 0 }), 7));
                lBsalida.Items.Add(" 0  0  1 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 0, 0, 1 }), 7));
                lBsalida.Items.Add(" 0  1  0 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 0, 1, 0 }), 7));
                lBsalida.Items.Add(" 0  1  1 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 0, 1, 1 }), 7));
                lBsalida.Items.Add(" 1  0  0 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 1, 0, 0 }), 7));
                lBsalida.Items.Add(" 1  0  1 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 1, 0, 1 }), 7));
                lBsalida.Items.Add(" 1  1  0 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 1, 1, 0 }), 7));
                lBsalida.Items.Add(" 1  1  1 : " + Math.Round(tresentradas.Operaneurona(new double[3] { 1, 1, 1 }), 7));
                
                lBsalida.Items.Add(" \n ");


            }
        }
        #endregion

         #region PARIDAD
        public void ProcesoParidad()
        {
            int counter = 0;
            while (!VF)
            {
                VF = true;
                lBsalida.Items.Add("\n--Epoca--: "+ ++counter);

                lBsalida.Items.Add("W1: "+cuatroentradas.Pesosiniciales[0]);
                lBsalida.Items.Add("W2: "+cuatroentradas.Pesosiniciales[1]);
                lBsalida.Items.Add("W3: "+cuatroentradas.Pesosiniciales[2]);
                lBsalida.Items.Add("W4: "+cuatroentradas.Pesosiniciales[3]);

                lBsalida.Items.Add("Umbral θ: "+cuatroentradas.Umbralinicial);

                if (cuatroentradas.Operaneurona(new double[4] { 0, 0, 0, 0 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 0, 0, 0 }, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 0, 0, 1 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 0, 0, 1 }, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 0, 1, 0 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 0, 1, 0 }, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 0, 1, 1 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 0, 1, 1 }, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 1, 0, 0 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 1, 0, 0 }, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 1, 0, 1 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 0, 1, 0, 1 }, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 1, 1, 0 }) !=1)
                {
                   cuatroentradas.OpNuevoAprendizaje(new double[4] {0, 1, 1, 0}, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 0, 1, 1, 1 }) !=0)
                {
                   cuatroentradas.OpNuevoAprendizaje(new double[4] {0, 1, 1, 1}, 1);
                    VF = false;
                }
                
                if (cuatroentradas.Operaneurona(new double[4] { 1, 0, 0, 0 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 0, 0, 0}, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 0, 0, 1 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 0, 0, 1}, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 0, 1, 0 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 0, 1, 0 }, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 0, 1, 1 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 0, 1, 1}, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 1, 0, 0 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 1, 0, 0}, 0);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 1, 0, 1 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 1, 0, 1}, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 1, 1, 0 }) !=0)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 1, 1, 0}, 1);
                    VF = false;
                }
                if (cuatroentradas.Operaneurona(new double[4] { 1, 1, 1, 1 }) !=1)
                {
                    cuatroentradas.OpNuevoAprendizaje(new double[4] { 1, 1, 1, 1}, 1);
                    VF = false;
                }

                lBsalida.Items.Add(" 0  0  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 0, 0, 0}), 7));
                lBsalida.Items.Add(" 0  0  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 0, 0, 1}), 7));
                lBsalida.Items.Add(" 0  1  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 0, 1, 0}), 7));
                lBsalida.Items.Add(" 0  1  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 0, 1, 1}), 7));
                lBsalida.Items.Add(" 0  0  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 1, 0, 0}), 7));
                lBsalida.Items.Add(" 0  0  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 1, 0, 1}), 7));
                lBsalida.Items.Add(" 0  1  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 1, 1, 0}), 7));
                lBsalida.Items.Add(" 0  1  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 0, 1, 1, 1}), 7));

                lBsalida.Items.Add(" 1  0  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 0, 0, 0}), 7));
                lBsalida.Items.Add(" 1  0  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 0, 0, 1}), 7));
                lBsalida.Items.Add(" 1  1  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 0, 1, 0}), 7));
                lBsalida.Items.Add(" 1  1  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 0, 1, 1}), 7));
                lBsalida.Items.Add(" 1  0  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 1, 0, 0}), 7));
                lBsalida.Items.Add(" 1  0  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 1, 0, 1}), 7));
                lBsalida.Items.Add(" 1  1  0 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 1, 1, 0}), 7));
                lBsalida.Items.Add(" 1  1  1 : " + Math.Round(cuatroentradas.Operaneurona(new double[4] { 1, 1, 1, 1}), 7));

                lBsalida.Items.Add(" \n ");
                if (++counter == 50)
                {
                    break;
                }
            }
            MessageBox.Show("No encontro solución");
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            lBsalida.Items.Clear();
            Application.Restart();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tRivera Rivera Juan Carlos");
        }
    }
}
