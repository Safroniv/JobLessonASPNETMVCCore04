
using System.Text.Json;

List<ProductFromJson> productsEntrance = new List<ProductFromJson>();

for (int i = 1; i <= 10; i++)
{
    ProductFromJson product = new ProductFromJson(i, $"продукт{i}", i * 2);

    productsEntrance.Add(product);
}
// сохранение данных json
using (FileStream fileStream = new FileStream("user.json", FileMode.OpenOrCreate))
{

    await JsonSerializer.SerializeAsync<List<ProductFromJson>>(fileStream, productsEntrance);
    Console.WriteLine("Данные были записаны в файл");
}

Console.WriteLine();
// чтение данных json
using (FileStream fileStream = new FileStream("user.json", FileMode.OpenOrCreate))
{
    Console.WriteLine("Чтение данных из файла ...");
    Console.WriteLine();

    List<ProductFromJson>? productsExit = await JsonSerializer.DeserializeAsync<List<ProductFromJson>>(fileStream);
    foreach (var i in productsExit)
    {
        Console.WriteLine($"ID: {i.ProductID},\t Наименование: {i.ProductName},\t Цена: {i.ProductPrice}");
    }

}

public class ProductFromJson
{
    public int ProductID { get; }

    public string ProductName { get; set; }

    public decimal ProductPrice { get; set; }

    public ProductFromJson(int productID, string productName, decimal productPrice)
    {
        ProductID = productID;
        ProductName = productName;
        ProductPrice = productPrice;
    }

}