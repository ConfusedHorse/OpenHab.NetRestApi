using System.Collections;

namespace OpenHAB.NetRestApi.Models
{
    public class RequestHeader
    {
        public RequestHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        #region Properties

        public string Name { get; }
        public string Value { get; }

        #endregion

        #region Operators

        public static RequestHeaderCollection operator &(RequestHeader left, RequestHeader right)
        {
            return new RequestHeaderCollection {left, right};
        }

        public static RequestHeaderCollection operator &(RequestHeaderCollection left, RequestHeader right)
        {
            left.Add(right);
            return left;
        }

        public static implicit operator RequestHeaderCollection (RequestHeader self)
        {
            return new RequestHeaderCollection {self};
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as RequestHeader);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }

        protected bool Equals(RequestHeader other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Value, other.Value);
        }

        #endregion

        #region Presets

        public static RequestHeader AcceptPlainText => new RequestHeader("Accept", "text/plain");
        public static RequestHeader ContentPlainText => new RequestHeader("Content-Type", "text/plain");

        public static RequestHeader AcceptJson => new RequestHeader("Accept", "application/json");
        public static RequestHeader ContentJson => new RequestHeader("Content-Type", "application/json");

        public static RequestHeaderCollection FullJson => AcceptJson & ContentJson;

        #endregion
    }

    public class RequestHeaderCollection : CollectionBase
    {
        #region Properties

        public RequestHeader this[int index]
        {
            get => (RequestHeader)List[index];
            set => List[index] = value;
        }

        #endregion

        #region Public Methods

        public int IndexOf(RequestHeader requestHeader)
        {
            if (requestHeader != null)
            {
                return List.IndexOf(requestHeader);
            }
            return -1;
        }

        public int Add(RequestHeader requestHeader)
        {
            if (requestHeader != null)
            {
                return List.Add(requestHeader);
            }
            return -1;
        }

        public void Remove(RequestHeader requestHeader)
        {
            InnerList.Remove(requestHeader);
        }

        public void AddRange(RequestHeaderCollection collection)
        {
            if (collection != null)
            {
                InnerList.AddRange(collection);
            }
        }

        public void Insert(int index, RequestHeader requestHeader)
        {
            if (index <= List.Count && requestHeader != null)
            {
                List.Insert(index, requestHeader);
            }
        }

        public bool Contains(RequestHeader requestHeader)
        {
            return List.Contains(requestHeader);
        }

        #endregion
    }
}