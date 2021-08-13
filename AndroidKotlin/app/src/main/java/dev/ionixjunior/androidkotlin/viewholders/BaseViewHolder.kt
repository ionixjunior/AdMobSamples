package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import androidx.recyclerview.widget.RecyclerView

abstract class BaseViewHolder(view: View) : RecyclerView.ViewHolder(view) {
    abstract fun bind(data: Any)
}