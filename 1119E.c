#include <stdio.h>
#include <limits.h>

#define min(a, b) ((a) < (b) ? (a) : (b))

typedef long long LL;
const int N = 300001;

int main() {
    LL a[N];
    int n;
    scanf("%d", &n);
    LL res = 0, aux = 0;
    for (int i = 0; i < n; i++) {
        scanf("%lld", &a[i]);
        LL minNum = min(aux, a[i] / 2);
        res += minNum;
        aux -= minNum;
        a[i] -= minNum * 2;

        res += a[i] / 3;
        aux += a[i] % 3;
    }
    printf("%lld\n", res);
    return 0;
}
