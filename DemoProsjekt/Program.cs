using DemoProsjekt;

// oppretter et objekt av klassen demo
Demo demo1 = new Demo();

Console.WriteLine($"ID={demo1.DemoId}, Number={demo1.DemoNumber}");

demo1.DemoId = 12;
demo1.DemoNumber = 14;


Console.WriteLine($"ETTER PROPERTIES: ID={demo1.DemoId}, Number={demo1.DemoNumber}");

Demo demo2 = new Demo(20, 40);
Console.WriteLine($"Demo2: ID={demo2.DemoId}, Number={demo2.DemoNumber}");
