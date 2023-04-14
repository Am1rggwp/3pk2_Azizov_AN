using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PZ_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stack<NotePadState> _undoStack = new Stack<NotePadState>();
        private readonly Stack<NotePadState> _redoStack = new Stack<NotePadState>();
        private NotePadState _currentStatenew;

        private Timer _timer;
        private int _snapshotsCount = -1;
        private NotePadState _currentState;
        private ElapsedEventHandler Timer_Elapsed;
        private const int MaxSnapshotsCount = 5;

        


        public MainWindow()
        {

            InitializeComponent();
            // Создаем начальное состояние блокнота
            _currentState = new NotePadState(textBox.Text, textBox.FontSize, textBox.FontStyle, textBox.FontWeight);

            // Создаем таймер с интервалом в 5 секунд
            _timer = new Timer(5000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();

            // Добавляем начальное состояние в стек отмены
            _undoStack.Push(_currentState);

        }


    

        private void DecreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontSize--;
        }

        private void IncreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontSize++;
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Bold)
            {
                textBox.FontWeight = FontWeights.Normal;
            }
            else
            {
                textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Normal;
            }
            else
            {
                textBox.FontStyle = FontStyles.Italic;
            }
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Contains(TextDecorations.Underline[0]))
            {
                textBox.TextDecorations.Remove(TextDecorations.Underline[0]);
            }
            else
            {
                textBox.TextDecorations.Add(TextDecorations.Underline[0]);
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (_undoStack.Count > 1)
            {
                // Удаляем текущее состояние из стека
                _undoStack.Pop();

                // Загружаем последнее состояние
                var previousState = _undoStack.Peek();

                // Обновляем текущее состояние
                _currentState = previousState;

                // Обновляем текстовое поле
                UpdateTextBoxFromState(previousState);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    writer.Write(textBox.Text);
                }
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (_snapshotsCount > _undoStack.Count - 1)
            {
                // Удаляем текущее состояние из стека
                _undoStack.Pop();

                // Загружаем следующее состояние
                var nextState = _undoStack.ElementAt(_snapshotsCount + 1);

                // Обновляем текущее состояние
                _currentState = nextState;
                _snapshotsCount++;

                // Обновляем текстовое поле
                UpdateTextBoxFromState(nextState);
            }
        }
        private void UpdateTextBoxFromState(NotePadState state)
        {
            textBox.Text = state.Text;
            textBox.FontSize = state.FontSize;
            textBox.FontWeight = state.FontWeight;
            textBox.FontStyle = state.FontStyle;
            textBox.TextDecorations = state.TextDecorations;
        }
    }
}
