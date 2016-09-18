using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudocu
{
    public partial class sudocu : Form
    {
        private string[,] array;
        private const int limit = 9;
        public sudocu()
        {
            InitializeComponent();
        }

        private void sudocu_Load(object sender, EventArgs e)
        {

        }
        
        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void repeats(int repeat_w, int repeat_h)
        {
            for (int l = 0; l < limit; l++)
            {
                for (int i = 0; i < limit; i++)
                {
                    for (int j = 0; j < limit; j++)
                    {
                        if (array[l, i] == array[l, j] && i != j && array[l, i] != "-1")
                        {
                            repeat_w++;
                            array[l, i] = "-1";
                        }
                        if (array[i, l] == array[j, l] && i != j && array[i, l] != "-1")
                        {
                            repeat_h++;
                            array[i, l] = "-1";
                        }
                    }
                }
            }
        }

        private bool is_empty()
        {
            bool result = false;
            int count = 0;
            for (int i = 0; i < limit; i++)
            {
                for(int j = 0; j < limit; j++)
                {
                    if (array[i, j] != "")
                        count++;
                }
            }
            if (count == limit * limit)
                result = false;
            else
                result = true;
            return result;
        }

        private bool written()
        {
            bool result = false;
            int repeat_w = 0, repeat_h = 0;
            repeats(repeat_w, repeat_h);
            if (repeat_h == 0 && repeat_w == 0 && is_empty() == false)
                result = true;
            else
                result = false;
            return result;
        }

        private void correct_input()
        {
            try
            {
                for(int i = 0; i < limit; i++)
                {
                    for(int j = 0; j< limit; j++)
                    {
                        if (array[i,j].Count() > 1 || array[i,j] == "0") 
                            throw new Exception("Input value must be >= 1 and <= 9");
                    }
                }
            }
            catch(Exception obj)
            {
                exception.Text = obj.Message;
            }
        }

        private void check_result(object sender, EventArgs e)
        {
            array = new string[9, 9] {{ square_1 .Text, square_2 .Text, square_3 .Text, square_4 .Text, square_5 .Text, square_6 .Text, square_7 .Text, square_8 .Text, square_9 .Text},
                                      { square_10.Text, square_11.Text, square_12.Text, square_13.Text, square_14.Text, square_15.Text, square_16.Text, square_17.Text, square_18.Text},
                                      { square_19.Text, square_20.Text, square_21.Text, square_22.Text, square_23.Text, square_24.Text, square_25.Text, square_26.Text, square_27.Text},
                                      { square_28.Text, square_29.Text, square_30.Text, square_31.Text, square_32.Text, square_33.Text, square_34.Text, square_35.Text, square_36.Text},
                                      { square_37.Text, square_38.Text, square_39.Text, square_40.Text, square_41.Text, square_42.Text, square_43.Text, square_44.Text, square_45.Text},
                                      { square_46.Text, square_47.Text, square_48.Text, square_49.Text, square_50.Text, square_51.Text, square_52.Text, square_53.Text, square_54.Text},
                                      { square_55.Text, square_56.Text, square_57.Text, square_58.Text, square_59.Text, square_60.Text, square_61.Text, square_62.Text, square_63.Text},
                                      { square_64.Text, square_65.Text, square_66.Text, square_67.Text, square_68.Text, square_69.Text, square_70.Text, square_71.Text, square_72.Text},
                                      { square_73.Text, square_74.Text, square_75.Text, square_76.Text, square_77.Text, square_78.Text, square_79.Text, square_80.Text, square_81.Text}};
            correct_input();
            if (written() == true)
                result.Text = "Written";
            else
                result.Text = "Not completed";
        }
    }
}
