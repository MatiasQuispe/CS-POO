namespace AppTurnos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plan plan1 = new Plan(1,"Oro");

            Plan plan2 = new Plan(2, "Plata");

            Plan plan3 = new Plan(3, "Cobre");

            Financiador financ1 = new Financiador(1, "OSDE");
            financ1.planes.Add(plan1);
            financ1.planes.Add(plan2);

            financ1.InformarDatos();
            financ1.ListarPlanes();

            Financiador financ2 = new Financiador(2, "PAMI");
            financ2.planes.Add(plan3);

            financ2.InformarDatos();
            financ2.ListarPlanes();

            Turno turno1 = new Turno(1001, "01/10/2022", "08:00", 30);
            Turno turno2 = new Turno(1002, "01/10/2022", "08:30", 30);
            Turno turno3 = new Turno(1003, "01/10/2022", "09:00", 30);
            Turno turno4 = new Turno(1004, "01/10/2022", "09:30", 30);
            Turno turno5 = new Turno(1005, "01/10/2022", "10:00", 30);

            Paciente pac1 = new Paciente(1, "Gonzales", "Laura");
            pac1.financiador = financ2;
            pac1.numeroAfiliado = "1234";
            pac1.plan = financ2.planes[0];
            pac1.turnos.Add(turno1);
            pac1.InformarDatos();

            Paciente pac2 = new Paciente(2, "Perez", "Juan");
            pac2.financiador = financ1;
            pac2.numeroAfiliado = "12345687";
            pac2.plan = financ1.planes[0];
            pac2.turnos.Add(turno2);
            pac2.turnos.Add(turno3);
            pac2.turnos.Add(turno4);
            pac2.turnos.Add(turno5);
            pac2.InformarDatos();

            
        }
    }

    class Persona
    {
        public string nombre { get; set; }

        public string apellido { get; set; }   
    }

    class Paciente : Persona
    {
        public Paciente(int id, string apellido, string nombre)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            turnos = new List<Turno>();
        }

        public int id { get; set; }

        public Financiador financiador { get; set; }

        public string numeroAfiliado { get; set; }

        public Plan plan { get; set; }

        public List<Turno> turnos { get; set; }

        public void InformarDatos()
        {
            Console.WriteLine($"Paciente Id:{id} - Apellido:{apellido}, Nombre:{nombre}");
            ListarTurnos();
        }

        private void ListarTurnos()
        {
            foreach (var turno in turnos)
            {
                Console.WriteLine($"       Turno Id:{turno.id} - Fecha:{turno.fecha} - Hora:{turno.hora}");
            }
        }
    }

    class Turno
    {

        public Turno(int id, string fecha, string hora, int duracion)
        {
            this.id = id;
            this.fecha = fecha;
            this.hora = hora;
            this.duracion = duracion;
        }

        public int id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int duracion { get; set; }

    }


    class Plan
    {
        public Plan(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }

        public int id { get; set; }
        public string nombre { get; set; }
    }

    class Financiador
    {
        public Financiador() {
            this.planes = new List<Plan>();
        }

        public Financiador(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.planes = new List<Plan>();
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public List<Plan> planes { get; set; }

        public void InformarDatos() {
            Console.WriteLine($"Financiador Id:{id} - Nombre{nombre}");
        }

        public void ListarPlanes()
        {
            foreach (var plan in planes ) {
                Console.WriteLine($"       Plan Id:{plan.id} - Nombre:{plan.nombre}");
            }
        }
    }
}