namespace ConsoleApp31
{
    public interface IAnimals
    {
        void Save(string voice, string name, string path);
        void Load(string path);
        void Say(string voice, string name);

    }
    public class AnimalController
    {
        readonly IAnimals animal;
        public AnimalController(IAnimals animal)
        {
            this.animal = animal;
        }
        public void Say(string name, string voice)
        {
            animal.Say(voice, name);
        }
        public void Save(string name, string path, string voice)
        {
            animal.Save(voice, name, path);
        }
        public void Load(string path)
        {
            animal.Load(path);
        }
    }
    class Animal : IAnimals
    {
        public void Say(string name, string voice)
        {
            Console.WriteLine($"{name} say {voice}");
        }
        public void Save(string name, string path, string voice)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(name);
                writer.WriteLine(voice);
            }
        }
        public void Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string name = reader.ReadLine();
                string voice = reader.ReadLine();
                Console.WriteLine($"{name} say {voice}");

            }
        }
    }

  
}
