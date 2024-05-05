import numpy as np
import matplotlib.pyplot as plt

# Tạo dữ liệu đầu vào
x = np.arange(1, 11) 
y1 = 2 * x + 5
y2 = 3 * x - 2
y3 = np.sin(x)  # Hàm số sin(x)

# Tạo ba hệ trục riêng biệt
fig, (ax1, ax2, ax3) = plt.subplots(1, 3, figsize=(12, 6))

# Vẽ đồ thị cho hệ trục thứ nhất
ax1.plot(x, y1, '--', color='blue', label='y = 2x + 5')
ax1.set_xlabel('Trục x')
ax1.set_ylabel('Trục y')
ax1.set_title('Đồ thị y = 2x + 5')
ax1.grid(True)

# Vẽ đồ thị cho hệ trục thứ hai
ax2.plot(x, y2, '-', color='red', label='y = 3x - 2')
ax2.set_xlabel('Trục x')
ax2.set_ylabel('Trục y')
ax2.set_title('Đồ thị y = 3x - 2')
ax2.grid(True)

# Vẽ đồ thị cho hệ trục thứ ba
ax3.plot(x, y3, '-.', color='green', label='y = sin(x)')
ax3.set_xlabel('Trục x')
ax3.set_ylabel('Trục y')
ax3.set_title('Đồ thị y = sin(x)')
ax3.grid(True)

# Hiển thị đồ thị
plt.tight_layout()
plt.show()
