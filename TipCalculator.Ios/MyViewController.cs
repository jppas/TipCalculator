using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace TipCalculator
{
    public class MyViewController : UIViewController
    {
        public MyViewController()
        {


        }

        //Lesson: Ex03-Step01-Override ViewDidLoad
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Lesson: Ex03-Step02-Change the Background Color
            this.View.BackgroundColor = UIColor.Yellow;

            //Lesson: Ex03-Step03-Set the Text Field
            //UITextField totalAmount = new UITextField(new CGRect(20,28,View.Bounds.Width-40,35));

            //Lesson: Ex03-Step04-Another way to Set the Text Field
            var rect = new CGRect(20, 28, View.Bounds.Width - 40, 35);
            var totalAmount = new UITextField(rect)
            {
                KeyboardType=UIKeyboardType.DecimalPad,
                BorderStyle=UITextBorderStyle.RoundedRect,
                Placeholder="Enter Total Amount"

            };

            //Lesson: Ex03-Step05-Create a Button
            UIButton calcButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0)
            };

            //Lesson: Ex03-Step06-Set the button properties
            calcButton.SetTitle("Calculate", UIControlState.Normal);

            //Lesson: Ex03-Step07-Create Label and Set the Label Properties
            UILabel resultLabel = new UILabel(new CGRect(0, 124, View.Bounds.Width, 40))
            {
                TextColor= UIColor.Blue,
                TextAlignment=UITextAlignment.Center,
                Font=UIFont.SystemFontOfSize(24),
                Text= "Tip is $0.00"
            };

            //Lesson: Ex03-Step08-Display the child views
            View.AddSubviews(totalAmount, calcButton, resultLabel);

            //Lesson: Ex04-Step01-Handle Button Taps
            //Since we are using fields local to ViewDidLoad, you will need to add an inline delegate handler using either an anoymous delegate, or a lambda expression. 
            //If you would prefer to use a traditional delegate method handler, move the field definitions for your three controls to the class so you can access them from the separate method.
            //The provided code below will use a lambda.
            calcButton.TouchUpInside += (s, e) => {
                double value = 0;
                Double.TryParse(totalAmount.Text, out value);
                resultLabel.Text = string.Format("Tip is {0:C}", value * 0.2);

                //Lesson: Ex04-Step02- Dismiss the keyboard
                totalAmount.ResignFirstResponder();

            };


        }

       
    }
}