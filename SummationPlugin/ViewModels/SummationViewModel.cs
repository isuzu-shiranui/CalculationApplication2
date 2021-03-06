﻿using Prism.Commands;
using System.ComponentModel.DataAnnotations;

namespace SummationPlugin.ViewModels
{
    class SummationViewModel : Commons.ViewModelBase
    {
        private double leftValue;
        [Required]
        [Range(0, double.MaxValue)]
        public double LeftValue
        {
            get { return leftValue; }
            set { SetProperty(ref leftValue, value); CalculationCommand.RaiseCanExecuteChanged(); }
        }

        private double rightValue;
        [Required]
        [Range(0, double.MaxValue)]
        public double RightValue
        {
            get { return rightValue; }
            set { SetProperty(ref rightValue, value); CalculationCommand.RaiseCanExecuteChanged(); }
        }

        private double resultValue;
        public double ResultValue
        {
            get { return resultValue; }
            set { SetProperty(ref resultValue, value); }
        }

        private DelegateCommand calculationCommand;
        public DelegateCommand CalculationCommand => calculationCommand ?? (new DelegateCommand(CalculationExecute, () => !HasErrors));

        private void CalculationExecute()
        {
            ResultValue = LeftValue + RightValue;
        }
    }
}
