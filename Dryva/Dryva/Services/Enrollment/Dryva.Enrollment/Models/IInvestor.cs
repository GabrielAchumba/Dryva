namespace Dryva.Enrollment.Models
{
    public interface IInvestor
    {
        long? Csn { get; set; }
        long Pin { get; set; }
        string FirstName { get; set; }
        string Gender { get; set; }
        string OtherName { get; set; }
        string Surname { get; set; }
        string Title { get; set; }

        decimal Percentage { get; set; }
    }
}