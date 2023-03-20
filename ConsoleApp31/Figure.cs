namespace ConsoleApp31
{
    public class Figure
    {
        public string Name { get; set; }
        public string Show { get; set; }
    }
    public interface IFigureIWriter
    {
        void Write(Figure figura);
    }
    public interface IFigureService
    {
        void Save(Figure figure);
        Figure[] Load();
    }

    public class FigureService : IFigureService
    {
        public string path;
        public FigureService(string path)
        {
            this.path = path;
        }
        public Figure[] Load()
        {
            var f = new Figure[0];
            if (!File.Exists(path))
                return f;
            using var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split("->");
                if (parts.Length != 2) continue;

                var newFigura = new Figure
                {
                    Name = parts[0],
                    Show = parts[1]
                };
                Array.Resize(ref f, f.Length + 1);
                f[^1] = newFigura;
            }
            return f;
        }

        public void Save(Figure tmp)
        {
            using var writer = new StreamWriter(path, true);
            writer.WriteLine($"{tmp.Name}->{tmp.Show}");
        }
    }
    public class FigureWriter : IFigureIWriter
    {
        public void Write(Figure f)
        {
            Console.WriteLine($"{f.Name} ");
            Console.WriteLine($"{f.Show}");
        }
    }

    public class FigureWriteFile : IFigureIWriter
    {
        public string path;
        public FigureWriteFile(string path)
        {
            this.path = path;
        }

        public void Write(Figure figura)
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{figura.Name} ");
                writer.WriteLine($"{figura.Show}");
                writer.WriteLine();
            }
        }
    }
    public class FigureController
    {
        private readonly IFigureService figureService;

        public FigureController(IFigureService figureService)
        {
            this.figureService = figureService;
        }

        public void Add()
        {
            Console.Write("Enter name:");
            var one = Console.ReadLine();
            Console.Write("Enter show:");
            var two = Console.ReadLine();
            var figura = new Figure
            {
                Name = one,
                Show = two
            };

            figureService.Save(figura);
            Console.WriteLine("Saved");
        }

        public void Figures()
        {
            var tmp = figureService.Load();
            foreach (var item in tmp)
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"{item.Show}");
            }
        }
    }
}
