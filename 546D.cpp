#include<bits/stdc++.h>
using namespace std;

const int tam = 5000001;
vector<int> listaNumPrimos;
vector<int> cont(tam);
bool naoPrimo[tam];
vector<int> dp(tam + 2);

void verificar() {
    listaNumPrimos.emplace_back(2);
    int lim = sqrt(tam + 5);
    for (int i = 3; i <= lim; i += 2) {
        if (!naoPrimo[i]) {
            listaNumPrimos.emplace_back(i);
            int add = i + i;
            for (int j = i + add; j <= tam - 1; j += add)
                naoPrimo[j] = true;
        }
    }
}

void calcular() {
    verificar();

    for (int i = 2; i < tam; i++) {
        int cnt = 0, num = i;
        if (!naoPrimo[i] && (i & 1))
            cnt = 1;
        else
            for (auto x : listaNumPrimos) {
                if (num % x == 0) {
                    num /= x;
                    cnt = 1 + dp[num];
                    break;
                } else if (x > num)
                    break;
            }
        dp[i] = cnt;
    }

    for (int i = 1; i < tam; i++)
        cont[i] = cont[i - 1] + dp[i];
}

int main() {
    int t;

    calcular();
    scanf("%d", &t);
    
    for (int i = 0; i < t; i++) {
        int a, b;
        scanf("%d%d", &a, &b);
        printf("%d\n", cont[a] - cont[b]);
    }

    return 0;
}
