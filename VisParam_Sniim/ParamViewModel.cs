using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveValidation;
using ReactiveValidation.Validators;
using ReactiveValidation.Extensions;

namespace VisParam_Sniim
{
    class ParamViewModel: ValidatableObject 
    {
        public ParamViewModel()
        {
            Validator = GetValidator();
        }

        private IObjectValidator GetValidator()
        {
            var builder = new ValidationBuilder<ParamViewModel>();

            builder.RuleFor(vm => vm.Radius).NotEmpty().WithMessage("Не оставляй поле пустым СЦУКА");
            builder.RuleFor(vm => vm.DConstant).NotEmpty().WithMessage("Не оставляй поле пустым СЦУКА");
            builder.RuleFor(vm => vm.TPolarization).NotEmpty().WithMessage("Не оставляй поле пустым СЦУКА"); 
            builder.RuleFor(vm => vm.Speed).NotEmpty().WithMessage("Не оставляй поле пустым СЦУКА");
            builder.RuleFor(vm => vm.MPolarization).NotNull().WithMessage("Не оставляй поле пустым СЦУКА");

            return builder.Build(this);
        }

        private string _radius;
        public string Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                OnPropertyChanged();
            }
        }
           
        private string _dConstant;
        public string DConstant
        {
            get => _dConstant;
            set
            {
                _dConstant = value;
                OnPropertyChanged();
            }
        }

        private string _tPolarization;
        public string TPolarization
        {
            get => _tPolarization;
            set
            {
                _tPolarization = value;
                OnPropertyChanged();
            }
        }

        private string _speed;
        public string Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                OnPropertyChanged();
            }
        }

        private string _mPolarization;
        public string MPolarization
        {
            get => _mPolarization;
            set
            {
                _mPolarization = value;
                OnPropertyChanged();
            }
        }
        
    }
}
