using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleApp
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<(string Subject, string Url)>> schedule = new Dictionary<string, List<(string, string)>>
        {
            { "ПОНЕДІЛОК", new List<(string, string)>
                {
                    ("Українська мова", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Математика", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761")
                }
            },
            { "ВІВТОРОК", new List<(string, string)>
                {
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Образотворче мистецтво", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Українська мова", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Музичне мистецтво", "https://us04web.zoom.us/j/75478077701?pwd=3BfCQlQ3lNjb7G8W8uhtqACaAtRdBT.1")
                }
            },
            { "СЕРЕДА", new List<(string, string)>
                {
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Українська мова", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Математика", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Інформатика", "https://us05web.zoom.us/j/83899662523?pwd=MjFAIQwmWi9Coqvbmgllr2rXS6kHfn.1"),
                    ("Фізичне виховання", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761")
                }
            },
            { "ЧЕТВЕР", new List<(string, string)>
                {
                    ("Математика", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Українська мова", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Англійська мова", "https://us04web.zoom.us/j/7265658974?pwd=NDVUYm1jMkJKYkJpUHdhUTFTeEo2Zz09"),
                    ("Фізичне виховання", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761")
                }
            },
            { "П'ЯТНИЦЯ", new List<(string, string)>
                {
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Фізичне виховання", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Українська мова", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Я досліджую світ", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761"),
                    ("Індивідуальне заняття", "https://us04web.zoom.us/j/6208331081?pwd=QzhBQlQ2Z0htMEt5dnh3NDkxRm5ldz09&omn=77214661761")
                }
            }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string selectedDay = button.Tag.ToString();

                // Очищуємо старі уроки
                LessonsPanel.Children.Clear();

                // Ховаємо текст "Вибери день!"
                MessageText.Visibility = Visibility.Collapsed;
                LessonsPanel.Visibility = Visibility.Visible;

                // Додаємо кнопки уроків
                if (schedule.ContainsKey(selectedDay))
                {
                    foreach (var (subject, url) in schedule[selectedDay])
                    {
                        Button lessonButton = new Button
                        {
                            Content = subject,
                            Margin = new Thickness(5),
                            Padding = new Thickness(10),
                            FontSize = 16,
                            Tag = url
                        };
                        lessonButton.Click += LessonButton_Click;
                        LessonsPanel.Children.Add(lessonButton);
                    }
                }
            }
        }

        private void LessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string url)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вдалося відкрити посилання: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
