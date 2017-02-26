#include <iostream>
#include <fstream>
struct pereche
{
    int q1,q2;
};
void addPereche(pereche *v, int a, int b, int &k)
{
    v[k].q1=a;
    v[k].q2=b;
    k++;
}
using namespace std;
void minimizare(int tabel[][4],int &n)
{
    int mec[20][20];
    //pas 1;
    int i, j, k=0;
    pereche v[100];
    for(i=0;i<n;i++)
    {
        for(j=0;j<i;j++)
        {
            if(tabel[i][2]!=tabel[j][2])
            {
                mec[i][j]=2;
                mec[j][i]=2;
            }
            else
            {
                mec[i][j]=0;
                mec[j][i]=0;
            }
        }
        mec[i][i]=1;
    }

    //pas 2
    while(k<n*n)
    {
        for(i=0;i<n;i++)
            for(j=0;j<i;j++)
                if(mec[i][j]==0)
                {
                    if( mec[tabel[i][1]][tabel[j][1]]==2 || mec[tabel[i][0]][tabel[j][0]]==2 )
                    {
                        mec[i][j]=2;
                        mec[j][i]=2;
                    }
                    if(k==n*n-1)
                    {
                        mec[i][j]=1;
                        mec[j][i]=1;
                    }

                }
        k++;
    }
    for(i=1;i<n;i++)
    {
        cout<<i<<" ";
        for(j=0;j<i;j++)
            cout<<(char)(60+mec[i][j]*9)<<" ";
        cout<<endl;
    }
    cout<<" ";
    for(i=0;i<n-1;i++)
        cout<<" "<<i;

    cout<<endl<<endl;
    for(i=0;i<n;i++)
    {
        for(j=0;j<n;j++)
            cout<<(char)3<<" ";
        cout<<endl;
    }
}

int main()
{
    ifstream fin("mini.in");
    int j,n,i,mec[20][20],tabel[20][4];
    fin>>n;
    for(i=0;i<n;i++)
        for(j=0;j<3;j++)
            fin>>tabel[i][j];
    minimizare(tabel,n);
}
