using System;
using System.Collections.Generic;
class Product{
    public int productid;
    public string productname;
    public int productprice;

    public int productstock;

    public Product(int proid, string proname, int proprice, int prostock) {
        productid = proid;
        productname = proname;
        productprice = proprice;
        productstock = prostock;
    }

    public override string ToString() {
        return $"Id: {productid}, Name: {productname}, Price : {productprice}, Stock: {productstock} ";
    }

}

class Suppliers{
    public int supplierid;
    public string suppliername;
    public bool supplierstatus;

    public Suppliers(int supid, string supname) {
        supplierid = supid;
        suppliername = supname;
        //supplierstatus = supstatus;
    }

    public override string ToString() {
        return $"Id: {supplierid}, Name: {suppliername}, Supplier Status{supplierstatus}";
    }

}

class Inventory{
    private List<Product> products;
    private List<Suppliers> suppliers;

    public Inventory() {
        products = new List<Product>();

        suppliers = new List<Suppliers>();
    }

    public void AddProduct(Product product) {
        products.Add(product);
    }

    public void DisplayProduct() {
        foreach (var pro in products) {
            Console.WriteLine(pro);
        }
    }

    public void AddSuppliers(Suppliers supplier) {
        suppliers.Add(supplier);
    }

    public void DisplaySuppliers() {
        foreach (var sup in suppliers) {
            Console.WriteLine(sup);
        }
    }

    public void IncreaseStock(string bname) {
        foreach (var x in products){
        if (x.productname == bname && x.productstock > 0){
            Console.WriteLine("The stock is increased");
            x.productstock +=10;
        } else {
            Console.WriteLine("This action is not available ath this time");
        }
        }
    }
    public void DecreaseStock(string bname) {
        foreach (var x in products){
        if (x.productname == bname && x.productstock > 0){
            Console.WriteLine("The stock is increased");
            x.productstock -=10;
        } else {
            Console.WriteLine("This action is not available ath this time");
        }
        }
    }


}

class Program {
    static void Main(string[] args) {
        Inventory inventory = new Inventory();

        for (int a=0; a<8; a++){
        Console.WriteLine("Select options from menu:");
        Console.WriteLine(@"
        1. Add Product
        2. Display Product
        3. Add Suppliors
        4. Display Suppliors
        5. Increase stock
        6. Decrease stock
        7. Exit");
        Console.WriteLine("Enter your option:");
        int num = Convert.ToInt32(Console.ReadLine());

        if(num == 1){
            Console.WriteLine("Enter your limit");
            int lim = Convert.ToInt32(Console.ReadLine());
            for(int x=0; x < lim; x++){
                Console.WriteLine("Enter your Product ID");
                int proid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your product name:");
                string proname = Console.ReadLine();
                Console.WriteLine("enter your price:");
                int proprice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your stock");
                int prostock = Convert.ToInt32(Console.ReadLine());
                inventory.AddProduct(new Product(proid, proname, proprice, prostock));
            }
        } else if(num==2){
            inventory.DisplayProduct();
        } else if(num == 3){
            Console.WriteLine("Enter your limit");
            int lim = Convert.ToInt32(Console.ReadLine());
            for(int x=0; x < lim; x++){
                Console.WriteLine("Enter your Supplier ID");
                int supid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Supplier name:");
                string supname = Console.ReadLine();
                inventory.AddSuppliers(new Suppliers(supid, supname));
            }
        } else if(num == 4){
            inventory.DisplaySuppliers();
        } else if(num==5){
            string bname;
            inventory.DisplayProduct();
            Console.WriteLine("Enter your product name");
            bname = Console.ReadLine();
            inventory.IncreaseStock(bname);

        } else if(num ==6){
            string bname;
            inventory.DisplayProduct();
            Console.WriteLine("Enter your product name");
            bname = Console.ReadLine();
            inventory.DecreaseStock(bname);
        } else if(num ==7){
            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();
        }

        }
    }
}