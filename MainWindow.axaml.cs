using Avalonia.Controls;
using demo1710.Context;
using demo1710.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo1710
{
    public partial class MainWindow : Window
    {
        List<Prod> prods = Helper.user724Context.Prods.Include(x => x.IdCategNavigation).Include(x => x.IdCustNavigation)
            .Include(x => x.IdManufNavigation).Include(x => x.IdEdIzmNavigation).ToList();
        public MainWindow()
        {
            InitializeComponent();
            updateList();
        }

        public void updateList()
        {
            prods = Helper.user724Context.Prods.Include(x => x.IdCategNavigation).Include(x => x.IdCustNavigation)
            .Include(x => x.IdManufNavigation).Include(x => x.IdEdIzmNavigation).ToList();
           

            switch (sort.SelectedIndex)
            {
                case 0:
                    prods =prods.OrderBy(x => x.Cost).ToList(); 
                    break;
                case 1:
                    prods = prods.OrderByDescending(x => x.Cost).ToList();
                    break ;
                case 2:
                default:
                    break;
            }
            switch (sort.SelectedIndex)
            {
                case 0:
                    prods =prods.Where(x => x.CurrDisc<10).ToList(); 
                    break;
                case 1:
                    prods = prods.Where(x => x.CurrDisc < 15 && x.CurrDisc>=10).ToList();
                    break;
                case 2:
                    prods = prods.Where(x => x.CurrDisc >= 15).ToList();
                    break;
                default:
                    break;
            }

            string searchText = search.Text ?? "";
            int count = searchText.Split(' ').Length;
            string[] values = new string[count];

            values = searchText.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in values)
            {
                if (!string.IsNullOrEmpty(s))
                { 
                    prods = prods.Where(x => x.NameProd == s).ToList();    
                }
                
            }

            var list = prods;
            listPr.ItemsSource = list;
        }

        private void Sort_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            updateList();
        }
        private void Filter_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            updateList();
        }

        private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            updateList();
        }
    }
}