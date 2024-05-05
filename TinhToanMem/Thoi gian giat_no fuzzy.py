# Hàm thuộc độ bẩn/dầu mỡ ít
def dg_s(x:int):
    if x >=50: return 0
    else: return round((50 - x)/50,2) 
# Hàm thuộc độ bẩn/dầu mỡ trung bình
def dg_m(x:int):
    if x >=50: return round((100 - x)/50,2)
    else: return round((x)/50,2) 
# Hàm thuộc độ bẩn/dầu mỡ nhiều
def dg_l(x:int):
    if x <=50: return 0
    else: return round((x - 50)/50,2) 
# Hàm thuộc độ thời gian giặt rất nhanh
def t_f(t:int):
    if t <= 4: return 1
    elif t >= 18: return 0
    else: return round((18 - t)/14,2)
# Hàm thuộc độ thời gian giặt nhanh
def t_s(t:int): 
    if (t <= 4) or (t >= 32): return 0
    elif t <= 18: return round((t-4)/14,2)
    else: return round((32 - t)/14,2)
# Hàm thuộc độ thời gian giặt trung bình
def t_m(t:int): 
    if (t <= 18) or (t >= 46): return 0
    elif t <= 32: return round((t-18)/14,2)
    else: return round((46 - t)/14,2)    
# Hàm thuộc độ thời gian giặt lâu
def t_l(t:int):
    if t <= 32: return 0
    elif t <= 46: return round((t-32)/14,2)
    else: return round((60 - t)/14,2)  
# Hàm thuộc độ thời gian giặt rất lâu
def t_v(t:int):
    if t <= 46: return 0
    else: return round((t - 46)/14,2)  

x = int(input('Nhap do ban [0 .. 100]: '))
y = int(input('Nhap do dau mo [0 .. 100]: '))

w1 = float(min(dg_l(x),dg_l(y))); w2 = float(min(dg_m(x),dg_l(y)))
w3 = float(min(dg_s(x),dg_l(y))); w4 = float(min(dg_l(x),dg_m(y)))
w5 = float(min(dg_m(x),dg_m(y))); w6 = float(min(dg_s(x),dg_m(y)))
w7 = float(min(dg_l(x),dg_s(y))); w8 = float(min(dg_m(x),dg_s(y)))
w9 = float(min(dg_s(x),dg_s(y)))

Y = range(61); sum = 0; m = 0
for i in Y:
    T = w1*float(t_v(i)) + (w2+w3+w4)*float(t_l(i)) + (w5+w6+w7)*float(t_m(i)) + w8*float(t_s(i)) + w9*float(t_f(i))
    sum = sum + i*T
    m = m + T
t0 = round(sum/m,2)
print(f'Voi do ban',x,'dau mo',y,'thi thoi gian giat la: ', t0,'phut')





