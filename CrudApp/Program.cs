using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // call interface Create Read Delete
        EmployeeCRD crd = new EmployeeCRD();
        crd.Add();
        crd.Read();
        crd.Delete();
    }
}

public class Employee
{
    public string EmployeeID { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}

public interface IEmployeeInterface
{
    void Add();
    void Read();
    void Delete();
}

public class EmployeeCRD : IEmployeeInterface
{
    public List<Employee> employees = new List<Employee>();
    public void Add()
    {
        // add data
        try
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { EmployeeID = "1001", FullName = "Adit", BirthDate = DateTime.ParseExact("1954-08-17", "yyyy-MM-dd", CultureInfo.InvariantCulture) });
            list.Add(new Employee { EmployeeID = "1002", FullName = "Anton", BirthDate = DateTime.ParseExact("1954-08-18", "yyyy-MM-dd", CultureInfo.InvariantCulture) });
            list.Add(new Employee { EmployeeID = "1003", FullName = "Amir", BirthDate = DateTime.ParseExact("1954-08-19", "yyyy-MM-dd", CultureInfo.InvariantCulture) });

            // validation data is not null (null handling)
            if (list is not null)
            {
                foreach (var data in list)
                {
                    employees.Add(data);
                }
            }
            
        }
        catch (Exception ex)
        {
            // error handling exception
            Console.WriteLine(ex.ToString());
        }
    }

    public void Read()
    {
        try
        {
            // read data
            foreach (var employee in employees)
            {
                Console.Write(employee.EmployeeID + " ");
                Console.Write(employee.FullName + " ");
                Console.WriteLine(employee.BirthDate.ToString("dd-MMM-yy"));
            }
        }
        catch (Exception ex)
        {
            // error handling exception
            Console.WriteLine(ex.ToString());
        }
    }

    public void Delete()
    {
        try
        {
            // delete data
            var data = employees.Where(d => d.EmployeeID == "1003").FirstOrDefault();
            employees.Remove(data);
        }
        catch (Exception ex)
        {
            // error handling exception
            Console.WriteLine(ex.ToString());
        }
    }
}
