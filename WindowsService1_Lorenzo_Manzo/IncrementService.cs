using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService1_Lorenzo_Manzo
{
    public class IncrementService : ServiceBase
    {
        private Timer timer;
        private int counter;

        public IncrementService()
        {
            ServiceName = "IncrementService";
            CanStop = true;
            CanPauseAndContinue = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            // Inicializar el contador
            counter = 0;

            // Crear el archivo txt si no existe
            string path = @"E:\Increment.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            // Inicializar el timer con un intervalo de 1 segundo
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            //Detener el timer
            timer.Stop();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            // Incrementar el contador
            counter++;

            // Escribir el contador en el archivo txt
            string path = @"E:\Increment.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(counter);
            }
        }

    }
}
