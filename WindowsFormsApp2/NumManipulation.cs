namespace WindowsFormsApp2
{
    class NumManipulation
    {
        public int FindMax(int a, int b, int c)
        {
            if (a < b)
            {
                if (b < c)
                {
                    return c;
                }
                else
                {
                    return b;
                }
            }
            else
            {
                return a;
            }
        }

        public int FindMin(int a, int b, int c)
        {
            if (a < b)
            {
                if (b < c)
                {
                    return b;
                }
                else
                {
                    return a;
                }
            }
            else
            {
                return c;
            }
        }
    }
}
