using OldPhonePadDecoder;

Console.WriteLine("Write numbers to decode!!! Type 'exit' to end.");

while (true)
{
    Console.Write("Numbers: ");
    string input = Console.ReadLine();

    if (input.ToLower() == "exit")
    {
        Console.WriteLine("Thank you.");
        break;
    }

    Console.WriteLine(PadDecoder.OldPhonePad(input));
    Console.WriteLine();
}