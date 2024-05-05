import numpy as np

def sigmoid(x):
    return 1 / (1 + np.exp(-x))

# Đầu vào và trọng số
P = np.array([1, 1])
w1 = np.array([-1, 1, 0, 0])
bias = 1

# Tính tổng trọng số và đầu vào
z = np.dot(P, w1) + bias

# Áp dụng hàm kích hoạt
output = sigmoid(z)

print("Ngõ ra của lớp ẩn: ", output)