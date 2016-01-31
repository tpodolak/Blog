using static System.Console;

namespace AbusingCollectionInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            var messagesAddInitializer = new StatusMessages
            {
                new StatusMessage("y"),
                new StatusMessage("x"),

            };
            DisplayMessages(nameof(messagesAddInitializer), messagesAddInitializer);

            var messagesAddStringInitializer = new StatusMessages
            {
                "y",
                "x"
            };
            DisplayMessages(nameof(messagesAddStringInitializer), messagesAddStringInitializer);

            var messagesAddAndTextInitializers = new StatusMessages
            {
                new StatusMessage("y"),
                "x"
            };
            DisplayMessages(nameof(messagesAddAndTextInitializers), messagesAddAndTextInitializers);

            var messagesExtensionInitializers = new StatusMessages
            {
                1,2,3
            };
            DisplayMessages(nameof(messagesExtensionInitializers), messagesExtensionInitializers);

            var messagesMultipleArgumentsInitializers = new StatusMessages
            {
                { 1, "x" }
            };
            DisplayMessages(nameof(messagesMultipleArgumentsInitializers), messagesMultipleArgumentsInitializers);

            var messagesMixAllInitializers = new StatusMessages
            {
                new StatusMessage("y"),
                "x",
                1,
                { 1, "x" }
            };
            DisplayMessages(nameof(messagesMixAllInitializers), messagesMixAllInitializers);

            ReadKey();
        }

        private static void DisplayMessages(string variableName, StatusMessages messages)
        {
            WriteLine($"Displaying messages for {variableName} collection ");
            foreach (var item in messages)
            {
                WriteLine(item.ToString());
            }
            WriteLine(string.Empty);
        }
    }
}
