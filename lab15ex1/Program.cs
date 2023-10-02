// See https://aka.ms/new-console-template for more information


/*Un student este caracterizat de
• Id (unic)
• Nume
• Prenume
• Varsta
• Specializare
• Specializarile vor fi
• Informatica
• Litere
• Constructii

• Initializati si populati o lista de
student si scrieti query-urile de
mai jos
• Pentru a fi mai usoara corectarea,
va rog sa puneti in comment
cerinta inaintea fiecarui query.

       1. Afisati cel mai in varsta student de la
        Informatica
        2. Afisati cel mai tanar student
        • In mai multe moduri
        3. Afisati in ordine crescatoare a varstei toti,
        studentii de la litere.
        4. Afisati primul student de la constructii cu
        varsta de peste 20 de ani
        5. Afisati studentii avand varsta egala cu
        varsta medie a studentilor
        6. Afisati, in ordinea descrescatoare a varstei,
        si in ordine alfabetica, dupa numele de
        familie si dupa numele mic, toti studentii
        cu varsta cuprinsa intre 18 si 35 de ani.
        7. Afisati ultimul elev din lista folosind linq
        8. Afisati mesajul “Exista si minori” daca in lista
        creeata exista si persone cu varsta mai mica de
        18 ani. In caz contar afesati “Nu exista minori”
        Suplimentar
        9. Folosind GroupBy, afisati toti studentii grupati
        in functie de varsta sub forma urmatoare
        Studentii cu varsta de 20 de ani
        Student1.toString
        Student2.toString
        Student3.toString
        Studentii cu varsta de 25 de ani
        */



using lab15ex1.Major;
using System.Xml.Serialization;

List<Student> students=new List<Student>();

students.Add(new Student { Id = 1, Age = 21, FirstName = "Sorin", LastName = "Popescu", Major = Major.Letters });
students.Add(new Student { Id = 2, Age = 18, FirstName = "Andrei", LastName = "Vasile", Major = Major.CivilEngineering });
students.Add(new Student { Id = 3, Age = 36, FirstName = "Elena", LastName = "Georgescu", Major = Major.It });
students.Add(new Student { Id = 4, Age = 42, FirstName = "George", LastName = "Mihai", Major = Major.It });
students.Add(new Student { Id = 5, Age = 24, FirstName = "Vasile", LastName = "Ion", Major = Major.Letters });
students.Add(new Student { Id = 6, Age = 33, FirstName = "Marcel", LastName = "Ilie", Major = Major.CivilEngineering });


 //Cel  mai in varsta student de la informatica
Console.WriteLine(students.Where(s=>s.Major==Major.It).OrderBy(s=>s.Age).LastOrDefault());
Console.WriteLine();


//Cel  mai tanar student
Console.WriteLine(students.OrderBy(s => s.Age).FirstOrDefault());
Console.WriteLine();
   //sau
/*var minAge=students.Min(s=>s.Age);
Console.WriteLine(students.FirstOrDefault(s=>s.Age==minAge));
Console.WriteLine();*/


//Ordine crescatoare a varstei, toti studentii de la litere
students.Where(s=>s.Major==Major.Letters)
         .OrderBy(s=>s.Age)
         .ToList()
         .ForEach(s=>Console.WriteLine(s));
Console.WriteLine();

//Primul student de la constructii cu varsta de peste 20 de ani
Console.WriteLine(students.FirstOrDefault(s => s.Major == Major.CivilEngineering && s.Age>20));     
Console.WriteLine();


 // Afisati studentii avand varsta egala cu varsta medie a studentilor
    var averageAge=students.Average(s=>s.Age);
    students.FindAll(s => s.Age == averageAge).ForEach(s => Console.WriteLine(s));
Console.WriteLine();

// Afisati in ordinea descrescatoare a varstei si in ordine alfabetica  dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 45 de ani.
 students.Where(s=>s.Age<35 && s.Age>18)
              .OrderBy(s=>s.LastName) 
              .ThenBy(s=>s.FirstName)
              .ToList()
              .ForEach(s=>Console.WriteLine(s));
Console.WriteLine();


 // Afisati ultimul elev din lista folosind linq.
Console.WriteLine(students.LastOrDefault());
Console.WriteLine();

//Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani. In caz contar afisati “Nu exista minori”.
    if (students.Any(s=>s.Age < 18))
{
    Console.WriteLine("Exista minori.");
}
else
{
     Console.WriteLine("Nu exista minori.");
}
     Console.WriteLine();


//Folosind GroupBy, afisati toti studentii grupati in functie de varsta.
   var ageGroups=students.GroupBy(s => s.Age).ToList();
   foreach(var gr in ageGroups)
{
    Console.WriteLine($"Studentii cu varsta de {gr.Key}");
    foreach(var stud in gr)
    {
        Console.WriteLine(stud);
    }
}             