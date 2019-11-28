namespace System.RAT
{
    public class rat
    {
        public ulong a; //nominator
        public ulong b; //denominator

        public rat(ulong a, ulong b)
        {
            if (b == 0)
                throw new Exception("DENOMINATOR EQUALS 0 EXCEPTION!");

            this.a = a;
            this.b = b;
        }

        public static rat operator +(rat a, rat b)
        {
            if (a.b != b.b)
            {
                ulong x = b.b;
                ulong y = a.b;

                a.Extend(x);
                b.Extend(y);
            }

            return new rat(a.a + b.a, a.b);
        }

        public static rat operator -(rat a, rat b)
        {
            if (a.b != b.b)
            {
                ulong x = b.b;
                ulong y = a.b;

                a.Extend(x);
                b.Extend(y);
            }

            return new rat(a.a - b.a, a.b);
        }

        public static explicit operator float(rat a)
        {
            return (float)a.a / (float)a.b;
        }

        public static explicit operator double(rat a)
        {
            return (double)a.a / (double)a.b;
        }

        public static explicit operator ulong(rat a)
        {
            if (a.b != 1)
                throw new Exception("BAD CONVERSION EXCEPTION");
            return a.a;
        }

        public static rat operator !(rat a)
        {
            return new rat(a.b, a.a);
        }

        public static rat operator *(rat a, rat b)
        {
            return new rat(a.a * b.a, a.b * b.b);
        }

        public static rat operator /(rat a, rat b)
        {
            return a * !b;
        }

        public static rat operator ++(rat a)
        {
            return new rat(++a.a, a.b);
        }

        public static rat operator --(rat a)
        {
            return new rat(--a.a, a.b);
        }

        public static bool operator !=(rat a, rat b)
        {
            if (a.b != b.b)
            {
                ulong x = b.b;
                ulong y = a.b;

                a.Extend(x);
                b.Extend(y);
            }
            return a.a != b.a;
        }

        public static ulong operator %(rat a, rat b)
        {
            float x = (float)(a / b);
            float y = (float)b;
            float z = (float)a;

            return (ulong)z - (ulong)x * (ulong)y;
        }

        public static bool operator ==(rat a, rat b)
        {
            if (a.b != b.b)
            {
                ulong x = b.b;
                ulong y = a.b;

                a.Extend(x);
                b.Extend(y);
            }

            return a.a == b.a;
        }

        public static rat Simplify(rat a, ulong x = 10000)
        {
            if (a.a % x != 0 || a.b % x != 0)
                return Simplify(a, --x);

            a.a /= x;
            a.b /= x;
            return a;
        }

        public void Simplify(ulong x)
        {
            if (a % x != 0 || b % x != 0)
                return;

            a /= x;
            b /= x;
        }

        public void Extend(ulong x)
        {
            a *= x;
            b *= x;
        }

        public override string ToString()
        {
            return (a > b ? a % b == 0 ? (a / b).ToString() : (a / b).ToString() + " " + (a % b).ToString() + "|" + b.ToString() : a == 0 ? 0.ToString() : b == 1 ? 
                a.ToString() : a.ToString() + "|" + b.ToString());
        }
    }
}
