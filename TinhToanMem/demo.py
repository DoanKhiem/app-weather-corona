import numpy as np
import matplotlib.pyplot as plt

from scipy.integrate import quad 
def Tmp(t): 
    return t*MuT(t) 
tu,_  = quad( Tmp,0,30 ) 
mau,_ = quad( MuT,0,30 ) 
t0 = tu/mau
print("Bồn có %.1f m3 và bể có %.1f m3, thời gian bơm: %.2f phút" % (y0,x0,t0))

x0,	y0	=	1.2,	5	
w1	= min(MuTf(y0),MuCf(x0))	
w2	= min(MuTf(y0),MuCm(x0))	
w3	= min(MuTf(y0),MuCe(x0))	
w4	= min(MuTe(y0),MuCf(x0))	
w5	= min(MuTe(y0),MuCm(x0))	
w6	= min(MuTe(y0),MuCe(x0))

C = np.linspace( 0,2 ) 
Cf = [MuCf(x) for x in C] 
Cm = [MuCm(x) for x in C] 
Ce = [MuCe(x) for x in C]

plt.plot(C, Cf, label="Đầy")
plt.plot(C, Cm, label="Còn vừa")
plt.plot(C, Cf, label="Gần cạn")
plt.legend(loc="Best")
plt.show()

def MuTf(y):
    if 0 <= y and y <= 1: 
        return y 
    elif 1 <= y and y <= 2: 
        return 1   
def MuTe(y): 
    if 0 <= y and y <= 1: 
        return 1 - y 
    elif 1 <= y and y <= 2: 
        return 0 


T = np.linspace( 0,2 ) 
Tf = [MuTf(y) for y in T] 
Te = [MuTe(y) for y in T] 
plt.plot( T, Tf ) 
plt.plot( T, Te ) 
plt.show()

Tg = np.linspace( 0,30 ) 
L = [MuL(t) for t in Tg] 
M = [MuM(t) for t in Tg] 
S = [MuS(t) for t in Tg]