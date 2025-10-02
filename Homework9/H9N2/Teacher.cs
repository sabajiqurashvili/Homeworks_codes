namespace H9N2;

public class Teacher
{
   public string Name { get; set; }
   public bool IsCertified { get; set; }

   public Teacher (string name, bool isCertified)
   {
      this.Name = Name;
      this.IsCertified = IsCertified;
   }

   public string Answer(Student student)
   {
      if (student.getSubject() == "Math") return $"3+4=7";
      if(student.getSubject() == "Chemistry") return $"H2O";
      if(student.getSubject() == "English") return $"Welcome {student.Name} in English class";
      return $"I am not competent in this {student.getSubject()} subject";
   }
    
    
}