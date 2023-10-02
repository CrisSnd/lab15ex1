using lab15ex1.Major;

class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age {  get; set; }

    public Major Major { get; set; }


    public override string ToString()
    
     =>$"{Id} {FirstName} {LastName} {Age} {Major}";

}
