namespace EncryptService {
    internal class Program {
        static void Main(string[] args) {
            string testString = "This is a test!";
            Console.WriteLine(Encrypt.EncryptString(testString, "123WOW"));
        }
    }
}