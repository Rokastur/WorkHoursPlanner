using System.Windows;

namespace WorkHoursPlanner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const int TYPICAL_HOURS_PER_DAY = 8;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnCalculateClick(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(RequiredFullWorkDays.Text, out var requiredFullWorkDays)
            && int.TryParse(DaysWorked.Text, out var daysWorked)
            && double.TryParse(HoursWorked.Text, out var hoursWorked))
        {
            var requiredHoursToWork = requiredFullWorkDays * TYPICAL_HOURS_PER_DAY;
            var remainingHoursToWork = requiredHoursToWork - hoursWorked;
            var remainingDaysToWork = requiredFullWorkDays - daysWorked;
            var averageHoursToWorkPerRemainingDay = remainingHoursToWork / remainingDaysToWork;

            var fmtString = TimeSpan.FromHours(averageHoursToWorkPerRemainingDay).ToString(@"hh\:mm");

            ResultText.Text = fmtString;
        }
        else
        {
            ResultText.Text = "Please enter valid numbers for all fields.";
        }
    }
}