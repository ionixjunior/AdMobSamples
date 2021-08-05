package dev.ionixjunior.androidkotlin

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

class NativeActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_native)
    }
}