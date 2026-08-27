import gymnasium as gym
import numpy as np

import gym_donkeycar

# env = gym.make("donkey-warrenbox-track-v0")

env = gym.make("donkey-box-push-v0")

obs, info = env.reset()
try:
    for _ in range(2):
        for _ in range(100):
            # drive straight with small speed
            action = np.array([0.0, 0.2])  
            # execute the action
            obs, reward, terminated, truncated, info = env.step(action)
            if "obj_pos" in info:
                print(f"Object Pose: {info['obj_pos']}")
            if "goal_pos" in info:
                print(f"Goal Pose: {info['goal_pos']}")
            print(f"Reward: {reward}")
        env.reset()
            
except KeyboardInterrupt:
    # You can kill the program using ctrl+c
    pass

    # Exit the scene
env.close()