Console.WriteLine(" Desconto de valores ");

Console.Write("Digite o nome do produto: ");
string produto = Console.ReadLine();
Console.Write("Qual o valor total: ");
double valor = double.Parse(Console.ReadLine());

if(valor < 100)
{
    Console.WriteLine("Este produto não tem desconto");
}
else if(valor < 500)
{
    double desconto = valor - (valor * 0.15);
    Console.WriteLine($"O produto {produto} tem um desconto de 15%, seu total será R$ {desconto}");
}
else
{
    double desconto = valor - (valor * 0.3);
    Console.WriteLine($"O produto {produto} tem um desconto de 30%, seu total será R$ {desconto}");
}





