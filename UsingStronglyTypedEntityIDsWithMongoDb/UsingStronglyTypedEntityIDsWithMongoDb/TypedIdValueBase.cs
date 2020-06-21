﻿using System;

 namespace UsingStronglyTypedEntityIDsWithMongoDb
{
    public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public string Value { get; }

        protected TypedIdValueBase(string value)
        {
            this.Value = value ?? throw new InvalidOperationException("Id value cannot be empty!");
        }

        public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y)
        {
            return !(x == y);
        }

        public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
        {
            if (Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TypedIdValueBase other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public bool Equals(TypedIdValueBase other)
        {
            return this.Value == other?.Value;
        }
    }
}