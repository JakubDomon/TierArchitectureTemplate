using System.Linq.Expressions;

namespace DataAccessLayer.Utils.UpdateHelper
{
    internal class UpdateHelper<T> where T : IFluentUpdatable
    {
        private readonly T _targetObject;
        private readonly T _dataObject;
        private readonly HashSet<string> _propertiesToUpdate = [];

        public UpdateHelper(T targetObject, T dataObject)
        {
            _targetObject = targetObject;
            _dataObject = dataObject;
        }

        public UpdateHelper<T> UpdateProperty<TProp>(Expression<Func<T, TProp>> propExpression)
        {
            if(propExpression.Body is MemberExpression memberExpression)
            {
                _propertiesToUpdate.Add(memberExpression.Member.Name);
            }
            return this;
        }

        public void ApplyUpdate()
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (_propertiesToUpdate.Contains(property.Name))
                {
                    var newValue = property.GetValue(_dataObject);
                    property.SetValue(_targetObject, newValue);
                }
            }
        }
    }
}
