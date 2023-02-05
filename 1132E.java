import java.util.Scanner;

public class Main {

    static long a[] = new long[10];
    static long w, ans;

    static void func(long pos, long sum) {
        if (pos > 8) {
            ans = Math.max(ans, sum);
            return;
        }

        long num = Math.min(a[(int) pos], (w - sum) / pos);

        for (int i = 1; i <= 8 && num >= 0; i++) {
            func(pos + 1, sum + pos * num);
            num--;
        }
    }

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        w = scan.nextLong();

        for (int i = 1; i <= 8; i++)
            a[i] = scan.nextLong();

        func(1, 0);

        System.out.println(ans);
    }
}